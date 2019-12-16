using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.Repositories
{
    public interface IUsersRepository : IRepository<Users>
    {
        Users FindByUserName(string username);
    }
}