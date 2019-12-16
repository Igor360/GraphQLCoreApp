using GraphQL.Types;

namespace WebApplication3GraphQL.GraphQL.Inputs
{
    public class UsersInputType : InputObjectGraphType
    {
        public UsersInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("Username");
            Field<NonNullGraphType<StringGraphType>>("Email");
            Field<NonNullGraphType<StringGraphType>>("Password");
            Field<NonNullGraphType<StringGraphType>>("FirstName");
            Field<NonNullGraphType<StringGraphType>>("LastName");
        }
    }
}