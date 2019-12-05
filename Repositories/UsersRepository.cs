using WebApplication3GraphQL.Contexts;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.Repositories
{
    public class UsersRepository : AbstractRepository<Users>, IUsersRepository
    {
        public UsersRepository(AppContext dbContext) : base(dbContext)
        {
        }
    }
}