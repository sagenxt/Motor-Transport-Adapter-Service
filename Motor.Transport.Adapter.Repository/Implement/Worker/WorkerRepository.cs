using System.Data;
using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Models.DTOs.Response;
using Motor.Transport.Adapter.Repository.Constant;
using Motor.Transport.Adapter.Repository.Interface.Worker;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Repository.Implement.Worker
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;

        public WorkerRepository(
            IConfiguration configuration,
            ILogger<WorkerRepository> logger,
            IApiResponseFactory apiResponseFactory,
            IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }

        public async Task<IApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>> GetWorkerControlBookSheetDetailsAsync(WorkerControlBookSheetRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_WORKER_CONTROLE_DETAILS_ON_WORKER_ID,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_WORKER_ID, ParameterValue=request.WorkerId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<WorkerControlBookSheetDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving worker control book sheet details based on worker id: {request.WorkerId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<WorkerControlBookSheetDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetWorkerControlBookSheetDetailsAsync));
            }
        }

        public async Task<IApiResponse<WorkerLoginResponse?>> GetWorkerLoginDetailsAsync(WorkerLoginRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_WORKER_LOGIN_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=request.MobileNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_OTP_CODE, ParameterValue=request.OtpCode, DataType=DbType.String, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<WorkerLoginResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving worker logged in details based on mobile number : {request.MobileNumber} and otp code : {request.OtpCode}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetWorkerLoginDetailsAsync));
            }
        }        

        public async Task<IApiResponse<WorkerDetailsResponse?>> PersistWorkerDetailsAsync(WorkerDetailsRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_PERSIST_WORKER_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_WORKER_ID, ParameterValue=request.WorkerId, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_FIRST_NAME, ParameterValue=request.FirstName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_MIDDLE_NAME, ParameterValue=request.MiddleName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_LAST_NAME, ParameterValue=request.LastName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=request.MobileNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_EMAIL_ID, ParameterValue=request.EmailId, DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName=DbConstants.P_STATUS_CODE, ParameterValue=0, DataType=DbType.Int32, Direction=ParameterDirection.Output, Size=2000},
                            new ParameterConfig { ParameterName=DbConstants.P_MESSAGE, ParameterValue=null, DataType=DbType.String, Direction=ParameterDirection.Output, Size=2000 }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteNonQueryAsync<WorkerDetailsResponse>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving worker details.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(PersistWorkerDetailsAsync));
            }
        }

        public async Task<IApiResponse<WorkerControlBookSheetResponse?>> PersistWorkerControlBookSheetDetailsAsync(WorkerControlBookSheetDetailsRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_PERSIST_WORKER_CONTROLE_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_SHEET_ID, ParameterValue=request.SheetId, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_WORKER_ID, ParameterValue=request.WorkerId, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_WORK_DATE, ParameterValue=request.WorkDate, DataType=DbType.Date, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_DAY_OF_WEEK, ParameterValue=request.DayOfWeek, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_ON_DUTY_OR_REST, ParameterValue=request.OnDutyOrRest, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_ENDING_WORK_DATE, ParameterValue=request.EndingWorkDate, DataType=DbType.Date, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PERIOD_OF_VEHICLE_IS_ON_ROAD, ParameterValue=request.PeriodOfVehiceIsOnRoad, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PERIOD_OF_INTERRUPTION, ParameterValue=request.PeriodOfInterruption, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_RUNNING_TIME, ParameterValue=request.RunningTime, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_SUBSIDIARY_WORK_TIME, ParameterValue=request.SubsidiaryWorkTime, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PERIOD_OF_MERE_ATTENDANCE, ParameterValue=request.PeriodOfMereAttendance, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_HOURS_OF_WORK, ParameterValue=request.HoursOfWork, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_REST_INTERVAL, ParameterValue=request.RestInterval, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_OVERTIME_LENGTH_WORKED, ParameterValue=request.OvertimeLengthWorked, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_OVERTIME_LENGTH_WORKED_REASON, ParameterValue=request.OvertimeLengthWorkedReason, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_REMARKS, ParameterValue=request.Remarks, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_LATITUDE, ParameterValue=request?.Coordinates?.Latitude, DataType=DbType.Decimal, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_LONGITUDE, ParameterValue=request?.Coordinates?.Longitude, DataType=DbType.Decimal, Direction=ParameterDirection.Input },
                            
                            new ParameterConfig { ParameterName=DbConstants.P_STATUS_CODE, ParameterValue=0, DataType=DbType.Int32, Direction=ParameterDirection.Output, Size=2000},
                            new ParameterConfig { ParameterName=DbConstants.P_MESSAGE, ParameterValue=null, DataType=DbType.String, Direction=ParameterDirection.Output, Size=2000 }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteNonQueryAsync<WorkerControlBookSheetResponse>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving worker control book sheet details.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerControlBookSheetResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(PersistWorkerControlBookSheetDetailsAsync));
            }
        }

        public async Task<IApiResponse<OtpVerificationResponse?>> PersistOtpVerificationDetailsAsync(OtpVerificationRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_PERSIST_OTP_VERIFCATION_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=request.MobileNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_OTP_CODE, ParameterValue=request.OtpCode, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CREATED_AT, ParameterValue=request.CreatedAt, DataType=DbType.DateTime, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_EXPIRES_AT, ParameterValue=request.ExpiresAt, DataType=DbType.DateTime, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName=DbConstants.P_STATUS_CODE, ParameterValue=0, DataType=DbType.Int32, Direction=ParameterDirection.Output, Size=2000},
                            new ParameterConfig { ParameterName=DbConstants.P_MESSAGE, ParameterValue=null, DataType=DbType.String, Direction=ParameterDirection.Output, Size=2000 }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteNonQueryAsync<OtpVerificationResponse>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving otp verification details.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<OtpVerificationResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(PersistOtpVerificationDetailsAsync));
            }
        }

        public async Task<IApiResponse<bool>> IsWorkerMobileNumberExistsOrNotAsync(string mobileNumber)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_WORKER_DETAILS_ON_MOBILE_NUMBER,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=mobileNumber, DataType=DbType.String, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<WorkerLoginResponse?>(dbStructureConfigData);
                if (response == null)
                {
                    return this._apiResponseFactory.ValidApiResponse(false);
                }
                return this._apiResponseFactory.ValidApiResponse(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving worker details based on mobile number : {mobileNumber}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<bool>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(IsWorkerMobileNumberExistsOrNotAsync));
            }
        }
    }
}
