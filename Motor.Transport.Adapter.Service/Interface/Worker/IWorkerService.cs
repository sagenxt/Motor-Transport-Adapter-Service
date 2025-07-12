using Core.ApiResponse.Interface;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Models.DTOs.Response;

namespace Motor.Transport.Adapter.Service.Interface.Worker
{
    public interface IWorkerService
    {
        Task<IApiResponse<WorkerDetailsResponse?>> PersistWorkerInfoAsync(WorkerDetailsRequest request);
        Task<IApiResponse<WorkerControlBookSheetResponse?>> PersistWorkerControlBookSheetInfoAsync(WorkerControlBookSheetDetailsRequest request);        
        Task<IApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>> RetrieveWorkerControlBookSheetDetailsAsync(WorkerControlBookSheetRequest request);
        Task<IApiResponse<GenerateOtpResponse?>> RequestOtpForWorkerLoginAsync(GenerateOtpRequest request);
        Task<IApiResponse<WorkerLoginResponse?>> VerifyOtpForWorkerLoginAsync(WorkerLoginRequest request);
    }
}
