using WebApplication3GraphQL.Contexts;
using WebApplication3GraphQL.Models;

namespace WebApplication3GraphQL.Repositories
{
    public class SensorDatasRepository : AbstractRepository<SensorDatas>, ISensorDatasRepository
    {
        public SensorDatasRepository(AppContext dbContext) : base(dbContext)
        {
        }
    }
}