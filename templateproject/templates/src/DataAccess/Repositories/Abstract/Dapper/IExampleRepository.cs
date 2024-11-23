using ZACx.Templates.WebApiProject.Entities.Entities;

namespace ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.Dapper
{
    public interface IExampleRepository
    {
        Task AddAsync(Example entity);
        Task<IEnumerable<Example>> GetAllAsync();
        Task<Example> GetByIdAsync(int exampleId);
        void UpdateAsync(Example entity);
    }
}
