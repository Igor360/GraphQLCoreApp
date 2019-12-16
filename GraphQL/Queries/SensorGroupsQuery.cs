using GraphQL.Types;
using WebApplication3GraphQL.GraphQL.Types;
using WebApplication3GraphQL.Services;

namespace WebApplication3GraphQL.GraphQL.Queries
{
    public class SensorGroupsQuery : ObjectGraphType
    {
        public SensorGroupsQuery(ISensorGroupsService service)
        {
            Field<ListGraphType<SensorGroupsType>>("Groups", resolve: context => service.All());
        }
    }
}