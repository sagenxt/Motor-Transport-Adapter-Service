using Core.ApiResponse.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motor.Transport.Adapter.Api.Controllers.BaseController;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Models.DTOs.Response;
using Motor.Transport.Adapter.Service.Interface.Worker;
using Motor.Transport.Adapter.Utility.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace Motor.Transport.Adapter.Api.Controllers
{
    public class WorkerController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWorkerService _workerService;

        public WorkerController(IApiResponseFactory apiResponseFactory,
                                IWorkerService workerService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._workerService = workerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerDetailsResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerDetailsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerPersistance)]
        public async Task<IActionResult> PersistWorkerDetails([FromBody] WorkerDetailsRequest request)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.PersistWorkerInfoAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerControlBookSheetResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerControlBookSheetResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerControlBookPersistance)]
        public async Task<IActionResult> PersistWorkerControlBookSheetDetails([FromBody] WorkerControlBookSheetDetailsRequest request)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.PersistWorkerControlBookSheetInfoAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<GenerateOtpResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<GenerateOtpResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.RequestOtpForWorkerLogin)]
        public async Task<IActionResult> RequestOtpForWorkerLogin([FromBody] GenerateOtpRequest request)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.RequestOtpForWorkerLoginAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerLoginResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerLoginResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.VerifyOtpForWorkerLogin)]
        public async Task<IActionResult> VerifyOtpForWorkerLogin([FromBody] WorkerLoginRequest request)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.VerifyOtpForWorkerLoginAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerControlBookSheetDetailsResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerControlBookSheetDetailsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerControlBookSheetDetails)]
        public async Task<IActionResult> RetrieveWorkerControlBookSheetDetails([FromBody] WorkerControlBookSheetRequest request)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.RetrieveWorkerControlBookSheetDetailsAsync(request));
        }

    }
}
