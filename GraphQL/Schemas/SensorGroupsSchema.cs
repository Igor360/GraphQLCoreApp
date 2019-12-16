using GraphQL.Types;
using WebApplication3GraphQL.GraphQL.Mutations;
using WebApplication3GraphQL.GraphQL.Queries;
using WebApplication3GraphQL.Services;

namespace WebApplication3GraphQL.GraphQL.Schemas
{
    public class SensorGroupsSchema : Schema
    {
        public SensorGroupsSchema(ISensorGroupsService service)
        {
            Query = new SensorGroupsQuery(service);
        }
    }
}