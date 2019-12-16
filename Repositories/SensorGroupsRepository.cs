using WebApplication3GraphQL.Contexts;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.Repositories
{
    public class SensorGroupsRepository : AbstractRepository<SensorsGroups>, ISensorsGroupsRepository
    {
        public SensorGroupsRepository(AppContext dbContext) : base(dbContext)
        {
        }
    }
}