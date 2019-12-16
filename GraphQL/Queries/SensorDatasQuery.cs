using GraphQL.Types;
using WebApplication3GraphQL.GraphQL.Types;
using WebApplication3GraphQL.Services;

namespace WebApplication3GraphQL.GraphQL.Queries
{
    public class SensorDatasQueery : ObjectGraphType
    {
        public SensorDatasQueery(ISensorDatasService service)
        {
            Field<ListGraphType<SensorDatasType>>("Data", resolve: context => service.All());
        }
    }
}