using GraphQL.Types;
using WebApplication3GraphQL.GraphQL.Inputs;
using WebApplication3GraphQL.GraphQL.Types;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Requests;
using WebApplication3GraphQL.Services;

namespace WebApplication3GraphQL.GraphQL.Mutations
{
    public class UsersMutation : ObjectGraphType<object>
    {
        public UsersMutation(IUsersService usersService)
        {
            Field<UsersType>("AddUser", arguments: new QueryArguments(
                    new QueryArgument<UsersInputType>() {Name = "user"}
                ),
                resolve: context =>
                {
                    var receivedUser = context.GetArgument<UserRequest>("user");
                    return usersService.RegisterUser(receivedUser);
                });
        }
    }
}