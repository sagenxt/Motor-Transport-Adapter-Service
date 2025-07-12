using Core.ApiResponse.Interface;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Models.DTOs.Response;

namespace Motor.Transport.Adapter.Repository.Interface.Worker
{
    public interface IWorkerRepository
    {
        Task<IApiResponse<WorkerDetailsResponse?>> PersistWorkerDetailsAsync(WorkerDetailsRequest request);
        Task<IApiResponse<WorkerControlBookSheetResponse?>> PersistWorkerControlBookSheetDetailsAsync(WorkerControlBookSheetDetailsRequest request);
        Task<IApiResponse<bool>> IsWorkerMobileNumberExistsOrNotAsync(string mobileNumber);
        Task<IApiResponse<WorkerLoginResponse?>> GetWorkerLoginDetailsAsync(WorkerLoginRequest request);
        Task<IApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>> GetWorkerControlBookSheetDetailsAsync(WorkerControlBookSheetRequest request);
        Task<IApiResponse<OtpVerificationResponse?>> PersistOtpVerificationDetailsAsync(OtpVerificationRequest request);
    }
}
