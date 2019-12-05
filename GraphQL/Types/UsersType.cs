using GraphQL.Types;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.GraphQL.Types
{
    public class UsersType : ObjectGraphType<Users>
    {
        public UsersType()
        {
            Field(x => x.Id);
            Field(x => x.Email);
            Field(x => x.EmailConfirmed);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Token);
        }
    }
}