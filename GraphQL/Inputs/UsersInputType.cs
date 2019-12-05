using GraphQL.Types;

namespace WebApplication3GraphQL.GraphQL.Inputs
{
    public class UsersInputType : InputObjectGraphType
    {
        public UsersInputType()
        {
            Field<StringGraphType>("Username");
            Field<StringGraphType>("Email");
            Field<StringGraphType>("Password");
            Field<StringGraphType>("FirstName");
            Field<StringGraphType>("LastName");
        }
    }
}