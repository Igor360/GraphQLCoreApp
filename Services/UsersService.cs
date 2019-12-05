using System.Collections.Generic;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Repositories;
using WebApplication3GraphQL.Requests;

namespace WebApplication3GraphQL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
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
            return  new Users();
        }
    }
}