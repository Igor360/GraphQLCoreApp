using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Requests;

namespace WebApplication3GraphQL.Services
{
    public interface IUsersService : IService<Users>
    {
        Users RegisterUser(UserRequest user);
        
        Users Authenticate(string username, string password);

    }
}