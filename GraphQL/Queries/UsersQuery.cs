using GraphQL.Types;
using WebApplication3GraphQL.GraphQL.Types;
using WebApplication3GraphQL.Services;

namespace WebApplication3GraphQL.GraphQL.Queries
{
    public class UsersQuery : ObjectGraphType
    {
        public UsersQuery(IUsersService usersService)
        {
            Field<ListGraphType<UsersType>>("users", resolve: context => usersService.All());
        }
    }
}