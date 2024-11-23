using ZACx.Templates.WebApiProject.Business.Services.Abstract;
using ZACx.Templates.WebApiProject.Core.Parameters.Examples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ZACx.Templates.WebApiProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        /// <summary>
        /// İlgili ExampleRequestParameter'a göre example bilgisini döner.
        /// </summary>
        /// <param name="requestParameter"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetExamples")]
        public async Task<IActionResult> GetAsync([FromBody] ExampleRequestParameter requestParameter)
        {
            var serviceResult = await _exampleService.GetExamplesAsync(requestParameter);
            return StatusCode((int)serviceResult.HttpStatusCode, serviceResult);
        }
    }
}