using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WebApplication3GraphQL.Exceptions;
using WebApplication3GraphQL.Helpers;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Repositories;
using WebApplication3GraphQL.Requests;
using WebApplication3GraphQL.Services.Helpers;

namespace WebApplication3GraphQL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        private readonly AppSettings _settings;

        private IMapper Mapper { get; }

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            Mapper = mapper;
        }

        public IEnumerable<Users> All()
        {
            return _usersRepository.All();
        }

        public Users Read(int id)
        {
            return _usersRepository.Read(id);
        }

        public void Update(int id, Users model)
        {
            if (model.Id == null)
            {
                model.Id = id;
            }

            _usersRepository.Update(model);
        }

        public void Create(Users model)
        {
            _usersRepository.Create(model);
        }

        public void Delete(int id)
        {
            _usersRepository.Delete(id);
        }

        public Users RegisterUser(UserRequest user)
        {
            // validation
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new AppException("Password is required");

            if (_usersRepository.FindByUserName(user.Username) != null)
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            var newUser = Mapper.Map<UserRequest, Users>(user);
            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            _usersRepository.Create(newUser);
            return newUser;
        }

        public Users Authenticate(string username, string password)
        {
            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = _usersRepository.FindByUserName(username);
            if (user == null || user.PasswordHash != passwordHash)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token).ToString();
            _usersRepository.Update(user);
            return user;
        }
    }
}