using ZACx.Templates.WebApiProject.Core.Common.Concrete;
using ZACx.Templates.WebApiProject.Core.Models.Response.Examples;
using ZACx.Templates.WebApiProject.Core.Parameters.Examples;

namespace ZACx.Templates.WebApiProject.Business.Services.Abstract
{
    public interface IExampleService
    {
        /// <summary>
        /// Get işlemlerini yapan method.
        /// </summary>
        /// <param name="exampleRequestParams"></param>
        /// <returns></returns>
        Task<ApiResult<ExampleResponseModel>> GetExamplesAsync(ExampleRequestParameter exampleRequestParams);
    }
}
