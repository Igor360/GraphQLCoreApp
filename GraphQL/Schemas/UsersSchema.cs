using GraphQL.Types;
using WebApplication3GraphQL.GraphQL.Mutations;
using WebApplication3GraphQL.GraphQL.Queries;
using WebApplication3GraphQL.Services;

namespace WebApplication3GraphQL.GraphQL.Schemas
{
    public class UsersSchema : Schema
    {
        public UsersSchema(IUsersService usersService)
        {
            Query = new UsersQuery(usersService);
            Mutation = new UsersMutation(usersService);
        }
    }
}