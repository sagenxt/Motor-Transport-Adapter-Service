using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.ApiResponse.Interface;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Models.DTOs.Response;
using Motor.Transport.Adapter.Repository.Interface.Worker;
using Motor.Transport.Adapter.Service.Interface.Worker;
using Motor.Transport.Adapter.Service.Validators.Worker;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Service.Implement.Worker
{
    public class WorkerService : IWorkerService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IValidator<WorkerDetailsRequest> _workerDetailsRequestValidator;
        private readonly IValidator<WorkerControlBookSheetDetailsRequest> _workerControlBookSheetDetailsRequestValidator;
        private readonly IValidator<WorkerLoginRequest> _workerLoginRequestValidator;
        private readonly IValidator<WorkerControlBookSheetRequest> _workerControlBookSheetRequestValidator;
        private readonly IValidator<GenerateOtpRequest> _generateOtpRequestValidator;
        private readonly IValidator<OtpVerificationRequest> _otpVerificationRequestValidator;
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(
            ILogger<WorkerService> logger,
            IMapper mapper,
            IApiResponseFactory apiResponseFactory,
            IValidator<WorkerDetailsRequest> workerDetailsRequestValidator,
            IValidator<WorkerControlBookSheetDetailsRequest> workerControlBookSheetDetailsRequestValidator,
            IValidator<WorkerLoginRequest> workerLoginRequestValidator,
            IValidator<WorkerControlBookSheetRequest> workerControlBookSheetRequestValidator,
            IValidator<GenerateOtpRequest> generateOtpRequestValidator,
            IValidator<OtpVerificationRequest> otpVerificationRequestValidator,
            IWorkerRepository workerRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _apiResponseFactory = apiResponseFactory;
            _workerDetailsRequestValidator = workerDetailsRequestValidator;
            _workerControlBookSheetDetailsRequestValidator = workerControlBookSheetDetailsRequestValidator;
            _workerLoginRequestValidator = workerLoginRequestValidator;
            _workerControlBookSheetRequestValidator = workerControlBookSheetRequestValidator;
            _generateOtpRequestValidator = generateOtpRequestValidator;
            _otpVerificationRequestValidator = otpVerificationRequestValidator;
            _workerRepository = workerRepository;
        }

        public async Task<IApiResponse<WorkerDetailsResponse?>> PersistWorkerInfoAsync(WorkerDetailsRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistWorkerInfoAsync)} started");
            try
            {
                var validationResult = await this._workerDetailsRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidWorkerDetailsRequest, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerDetailsResponse?>(string.Format(WarningMessages.InvalidWorkerDetailsRequest, errorMessage), nameof(PersistWorkerInfoAsync));
                }
                var response = await this._workerRepository.PersistWorkerDetailsAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<WorkerDetailsResponse?>(response.Data.Message ?? "Unknown error", nameof(PersistWorkerInfoAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistWorkerInfoAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while persisting worker information.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerDetailsResponse?>("" ?? "Unknown error", nameof(PersistWorkerInfoAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting worker information.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerDetailsResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(PersistWorkerInfoAsync));
            }
        }

        public async Task<IApiResponse<WorkerControlBookSheetResponse?>> PersistWorkerControlBookSheetInfoAsync(WorkerControlBookSheetDetailsRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistWorkerControlBookSheetInfoAsync)} started");
            try
            {
                var validationResult = await this._workerControlBookSheetDetailsRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidWorkercontrolBookSheetDetailsRequest, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerControlBookSheetResponse?>(string.Format(WarningMessages.InvalidWorkercontrolBookSheetDetailsRequest, errorMessage), nameof(PersistWorkerControlBookSheetInfoAsync));
                }
                var response = await this._workerRepository.PersistWorkerControlBookSheetDetailsAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<WorkerControlBookSheetResponse?>(response.Data.Message ?? "Unknown error", nameof(PersistWorkerControlBookSheetInfoAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistWorkerControlBookSheetInfoAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while persisting worker control book sheet information.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerControlBookSheetResponse?>("" ?? "Unknown error", nameof(PersistWorkerControlBookSheetInfoAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting worker control book sheet information.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerControlBookSheetResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(PersistWorkerControlBookSheetInfoAsync));
            }
        }



        public async Task<IApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>> RetrieveWorkerControlBookSheetDetailsAsync(WorkerControlBookSheetRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkerControlBookSheetDetailsAsync)} started");
            try
            {
                var validationResult = await this._workerControlBookSheetRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForWorkercontrolBookSheetDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>(string.Format(WarningMessages.InvalidRequestForWorkercontrolBookSheetDetails, errorMessage), nameof(RetrieveWorkerControlBookSheetDetailsAsync));
                }
                var response = await this._workerRepository.GetWorkerControlBookSheetDetailsAsync(request);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving worker control book sheet details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>("" ?? "Unknown error", nameof(RetrieveWorkerControlBookSheetDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkerControlBookSheetDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving worker control book sheet details based on worker id: {request.WorkerId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveWorkerControlBookSheetDetailsAsync));
            }
        }

        public async Task<IApiResponse<GenerateOtpResponse?>> RequestOtpForWorkerLoginAsync(GenerateOtpRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(RequestOtpForWorkerLoginAsync)} started");
            try
            {
                var validationResult = await this._generateOtpRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidGenerateOtpRequest, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<GenerateOtpResponse?>(string.Format(WarningMessages.InvalidGenerateOtpRequest, errorMessage), nameof(RequestOtpForWorkerLoginAsync));
                }

                //Checking Worker mobile number exists or not
                var isWorkerMobileNumberExists = await this._workerRepository.IsWorkerMobileNumberExistsOrNotAsync(request.MobileNumber);
                if (isWorkerMobileNumberExists.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while checking worker mobile number existence.");
                    return this._apiResponseFactory.BadRequestApiResponse<GenerateOtpResponse?>("", nameof(RequestOtpForWorkerLoginAsync));
                }
                if (!isWorkerMobileNumberExists.Data)
                {
                    this._logger.LogWarning("Worker mobile number does not exist.");
                    return this._apiResponseFactory.BadRequestApiResponse<GenerateOtpResponse?>("Worker mobile number does not exist.", nameof(RequestOtpForWorkerLoginAsync));
                }

                var otpCode = new Random().Next(100000, 999999).ToString();
                var expiresAt = DateTime.UtcNow.AddMinutes(15);
                var otpVerificationRequest = new OtpVerificationRequest
                {
                    MobileNumber = request.MobileNumber,
                    OtpCode = otpCode,
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = expiresAt
                };

                var response = await PersistOtpVerificationDetailsAsync(otpVerificationRequest);
                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while persisting OTP verification details.");
                    return this._apiResponseFactory.BadRequestApiResponse<GenerateOtpResponse?>(response.Data?.Message ?? "Unknown error", nameof(RequestOtpForWorkerLoginAsync));
                }
                if (response.Data != null && response.Data.StatusCode != 200)
                {
                    this._logger.LogWarning(response.Data.Message);
                    return this._apiResponseFactory.BadRequestApiResponse<GenerateOtpResponse?>(response.Data.Message ?? "Unknown error", nameof(RequestOtpForWorkerLoginAsync));
                }

                // Send the OTP to the worker's mobile number via SMS.
                var sendOtpResponse = await SendOtp(request.MobileNumber);
                //var finalResponse = this._mapper.Map<GenerateOtpResponse?>(sendOtpResponse);

                this._logger.LogInformation($"Method Name : {nameof(RequestOtpForWorkerLoginAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(sendOtpResponse);                
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred while requesting OTP for worker login.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<GenerateOtpResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(RequestOtpForWorkerLoginAsync));
            }
        }

        public async Task<IApiResponse<WorkerLoginResponse?>> VerifyOtpForWorkerLoginAsync(WorkerLoginRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(VerifyOtpForWorkerLoginAsync)} started");
            try
            {
                var validationResult = await this._workerLoginRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForVerifyingWorkerLoginDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerLoginResponse?>(string.Format(WarningMessages.InvalidRequestForVerifyingWorkerLoginDetails, errorMessage), nameof(VerifyOtpForWorkerLoginAsync));
                }
                var response = await this._workerRepository.GetWorkerLoginDetailsAsync(request);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while verifying otp for worker login details.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerLoginResponse?>("" ?? "Unknown error", nameof(VerifyOtpForWorkerLoginAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(VerifyOtpForWorkerLoginAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurredwhile verifying otp for worker login details based on mobile number: {request.MobileNumber} and otp code: {request.OtpCode}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(VerifyOtpForWorkerLoginAsync));
            }
        }

        private async Task<IApiResponse<OtpVerificationResponse?>> PersistOtpVerificationDetailsAsync(OtpVerificationRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistOtpVerificationDetailsAsync)} started");
            try
            {
                var validationResult = await this._otpVerificationRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidOtpVerificationDetailsRequest, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<OtpVerificationResponse?>(string.Format(WarningMessages.InvalidOtpVerificationDetailsRequest, errorMessage), nameof(PersistOtpVerificationDetailsAsync));
                }
                var response = await this._workerRepository.PersistOtpVerificationDetailsAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<OtpVerificationResponse?>(response.Data.Message ?? "Unknown error", nameof(PersistOtpVerificationDetailsAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistOtpVerificationDetailsAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while persisting otp verification information.");
                    return this._apiResponseFactory.BadRequestApiResponse<OtpVerificationResponse?>("" ?? "Unknown error", nameof(PersistOtpVerificationDetailsAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting otp verification information.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<OtpVerificationResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(PersistOtpVerificationDetailsAsync));
            }
        }

        private async Task<GenerateOtpResponse?> SendOtp(string mobileNumber)
        {
            var client = new HttpClient();

            string authKey = "459818AxufzdxH68715606P1";
            string mobile = mobileNumber;
            string templateId = "687160d0d6fc05226601d2b2";
            //string senderId = "sagenxt123"; 

            var url = $"https://api.msg91.com/api/v5/otp?template_id={templateId}&mobile={mobile}&authkey={authKey}";

            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var otpResponse = new GenerateOtpResponse
                {
                    StatusCode = (int)response.StatusCode,
                    Message = "OTP sent successfully.",
                };             
                return otpResponse;
            }
            else
            {
                var otpResponse = new GenerateOtpResponse
                {
                    StatusCode = (int)response.StatusCode,
                    Message = "Failed to send OTP.",
                }; ;
                return otpResponse;
            }
        }
    }
}
