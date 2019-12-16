using GraphQL.Types;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.GraphQL.Types
{
    public class LoginType: ObjectGraphType<Users>
    {
        public LoginType()
        {
            Field(x => x.Token);
        }
    }
}