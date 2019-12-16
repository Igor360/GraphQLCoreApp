using GraphQL.Types;

namespace WebApplication3GraphQL.GraphQL.Inputs
{
    public class LoginInputType : InputObjectGraphType
    {
        public LoginInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("Username");
            Field<NonNullGraphType<StringGraphType>>("Password");
        }
    }
}