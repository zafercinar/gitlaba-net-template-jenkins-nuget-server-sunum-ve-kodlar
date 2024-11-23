using ZACx.Templates.WebApiProject.Entities.Entities;
using ZACx.Templates.WebApiProject.DataAccess.Contexts;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.EntityFramework;

namespace ZACx.Templates.WebApiProject.DataAccess.Repositories.Concrete.EntityFramework
{
    public class ExampleRepository : GenericRepository<Example>, IExampleRepository
    {
        public ExampleRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
