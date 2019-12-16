using GraphQL.Types;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.GraphQL.Types
{
    public class SensorDatasType : ObjectGraphType<SensorDatas>
    {
        public SensorDatasType()
        {
            Field(x => x.Id);
            Field(x => x.Code);
            Field(x => x.Name);
//            Field(x => x.GroupSensorses);
        }
    }
}