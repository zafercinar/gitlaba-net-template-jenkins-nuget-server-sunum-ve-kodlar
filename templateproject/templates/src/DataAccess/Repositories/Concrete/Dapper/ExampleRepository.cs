using Dapper;
using ZACx.Templates.WebApiProject.Entities.Entities;
using System.Data.SqlClient;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.Dapper;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Concrete.Dapper.Queries;

namespace ZACx.Templates.WebApiProject.DataAccess.Repositories.Concrete.Dapper
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly string _connectionString;
        public ExampleRepository()
        {
            _connectionString = "ConnectionStringBurayaYazilacaktir";
        }
        public async Task AddAsync(Example entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql: ExampleQueries.EXAMPLES_INSERT_QUERY, param: entity, commandTimeout: 0);
            }
        }

        public async Task<IEnumerable<Example>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Example>(sql: ExampleQueries.EXAMPLES_GETALL_QUERY, commandTimeout: 0);
            }
        }

        public async Task<Example> GetByIdAsync(int exampleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Example>(sql: ExampleQueries.EXAMPLES_GETBYID_QUERY, param: new { ExampleId = exampleId }, commandTimeout: 0);
            }
        }

        public async void UpdateAsync(Example entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql: ExampleQueries.EXAMPLES_UPDATE_QUERY, param: entity, commandTimeout: 0);
            }
        }
    }
}
