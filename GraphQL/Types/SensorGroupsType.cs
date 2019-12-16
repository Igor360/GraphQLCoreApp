using GraphQL.Types;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.GraphQL.Types
{
    public class SensorGroupsType: ObjectGraphType<SensorsGroups>
    {
        public SensorGroupsType()
        {
            Field(x => x.Id);
//            Field(x => x.SensorDatases);
            Field(x => x.Name);
//            Field(x => x.User);
        }
    }
}