using AutoMapper;
using ZACx.Templates.WebApiProject.Business.Validators.Examples;
using ZACx.Templates.WebApiProject.Core.Common.Concrete;
using ZACx.Templates.WebApiProject.Core.Constants;
using ZACx.Templates.WebApiProject.Core.DTOs.Examples;
using ZACx.Templates.WebApiProject.Core.Enums;
using ZACx.Templates.WebApiProject.Core.Models.Response.Examples;
using ZACx.Templates.WebApiProject.Core.Parameters.Examples;
using ZACx.Templates.WebApiProject.DataAccess.Repositories.Abstract.EntityFramework;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using ZACx.Templates.WebApiProject.Business.Services.Abstract;

namespace ZACx.Templates.WebApiProject.Business.Services.Concrete
{
    public class ExampleService : IExampleService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ExampleService> _logger;
        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IMapper mapper, ILogger<ExampleService> logger, IExampleRepository exampleRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _exampleRepository = exampleRepository;
        }

        public async Task<ApiResult<ExampleResponseModel>> GetExamplesAsync(ExampleRequestParameter exampleRequestParams)
        {
            //Logları takip edebilmek için bu örnekte bu yapı kullanılmıştır.
            var logId = Guid.NewGuid();

            // Logların içerisine CorelationId propertysi eklemek ve logu takip bu property ile takip etmek için aşağıdaki düzenleme yapılmıştır.
            // Microsoft.Extensions.Logging kütüphanesi ile kullanımı için BeginScope
            // Serilog kütüphanesi ile kullanım için ise ForContext kullanılması gerekir.
            // _logger.ForContext("CorelationId",logId).Information("Log message")
            using (_logger.BeginScope(new Dictionary<string, object> { { "CorelationId", logId } }))
            {
                try
                {
                    //Süreç olarak başlangıç kısmında log atılması bekleniyorsa alttaki satırı açabilirsin.
                    //_logger.LogInformation($"{GetType().FullName}.{nameof(GetExamplesAsync)}.{MessageResponseType.Started}{Environment.NewLine}ExampleRequestParameter:{JsonSerializer.Serialize(exampleRequestParams)}");

                    #region Model Validate Process

                    var modelValidator = new ExampleRequestParameterValidator();
                    var modelValidatorResponse = await modelValidator.ValidateAsync(exampleRequestParams);
                    if (!modelValidatorResponse.IsValid)
                    {
                        var errorMessages = new StringBuilder();
                        modelValidatorResponse.Errors.ForEach(x => errorMessages.AppendLine(x.ErrorMessage));
                        return new ApiResult<ExampleResponseModel>
                        {
                            HttpStatusCode = HttpStatusCode.NotAcceptable,
                            MessageCode = $"{(int)HttpStatusCode.NotAcceptable}{(int)ApiMessageCode.Default}",
                            UserMessage = MessageConstant.INVALID_VALIDATION,
                            InternalMessage = errorMessages.ToString(),
                            Data = new ExampleResponseModel
                            {
                                //CurrentPageDataCount = 0,
                                //CurrentPageNumber = 0,
                                //TotalDataCount = 0,
                                //TotalPageNumber = 0,
                                Example = null,
                            }
                        };
                    }

                    #endregion

                    #region Get Data & Mapping Process

                    var getExampleSingleResult = await _exampleRepository.GetSingleAsync(p => p.Code == exampleRequestParams.Code);

                    var exampleDtoResult = _mapper.Map<ExampleDto>(getExampleSingleResult);

                    var exampleResponseResult = _mapper.Map<ExampleResponse>(exampleDtoResult);

                    #endregion

                    //Süreç olarak başarılı sonucun loglanması bekleniyorsa alttaki satırı açabilirsin.
                    //_logger.LogInformation($"{GetType().FullName}.{nameof(GetExamplesAsync)}.{MessageResponseType.Success}{Environment.NewLine}ExampleRequestParameter:{JsonSerializer.Serialize(exampleRequestParams)}");

                    return new ApiResult<ExampleResponseModel>
                    {
                        HttpStatusCode = HttpStatusCode.OK,
                        MessageCode = $"{(int)HttpStatusCode.OK}{(int)ApiMessageCode.Default}",
                        UserMessage = MessageConstant.SUCCESSFUL_PROCESS,
                        InternalMessage = MessageConstant.SUCCESSFUL_PROCESS,
                        Data = new ExampleResponseModel
                        {
                            //CurrentPageDataCount = 0,
                            //CurrentPageNumber = 0,
                            //TotalDataCount = 0,
                            //TotalPageNumber = 0,
                            Example = exampleResponseResult,
                        }
                    };
                }
                catch (Exception exception)
                {
                    _logger.LogError($"{GetType().FullName}.{nameof(GetExamplesAsync)}.{MessageResponseType.Error}{Environment.NewLine}ErrorDetails:{exception.Message}");
                    return new ApiResult<ExampleResponseModel>
                    {
                        HttpStatusCode = HttpStatusCode.ExpectationFailed,
                        MessageCode = $"{(int)HttpStatusCode.ExpectationFailed}{(int)ApiMessageCode.Default}",
                        UserMessage = MessageConstant.UNSUCCESSFUL_PROCESS,
                        InternalMessage = $"{MessageConstant.UNSUCCESSFUL_PROCESS} Detay:{exception.Message}",
                        Data = new ExampleResponseModel
                        {
                            //CurrentPageDataCount = 0,
                            //CurrentPageNumber = 0,
                            //TotalDataCount = 0,
                            //TotalPageNumber = 0,
                            Example = null,
                        }
                    };
                }
                //finally
                //{
                //    //Dispose edilmesi gereken bir durum olması durumda aktif edilebilir.

                //    //Süreç olarak işlem başarılı da olsa 
                //    _logger.LogInformation($"{GetType().FullName}.{nameof(GetExamplesAsync)}.{MessageResponseType.Finished}{Environment.NewLine}İşlem tamamlandı.");
                //}
            }

        }
    }
}
