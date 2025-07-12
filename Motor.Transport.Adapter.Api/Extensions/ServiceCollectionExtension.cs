using Core.ApiResponse.Implementation;
using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using FluentValidation;
using Motor.Transport.Adapter.Models.DTOs.Request.Worker;
using Motor.Transport.Adapter.Repository.Implement.Worker;
using Motor.Transport.Adapter.Repository.Interface.Worker;
using Motor.Transport.Adapter.Service.Implement.Worker;
using Motor.Transport.Adapter.Service.Interface.Worker;
using Motor.Transport.Adapter.Service.Validators.Worker;

namespace Motor.Transport.Adapter.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add IApiResponseFactory to the container
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ITraceProvider, TraceProvider>();
            services.AddTransient<IApiResponseFactory, ApiResponseFactory>();

            services.AddScoped<IHttpStatusCodeResolver, HttpStatusCodeResolver>();

            // Add Core Data Access service to the container.
            services.AddScoped<IWrapperDbContext, WrapperDbContext>();

            // Add Repositories to the container.
            services.AddScoped<IWorkerRepository, WorkerRepository>();

            // Add Services to the container.
            services.AddScoped<IWorkerService, WorkerService>();

            // Add Validators to the container.
            services.AddScoped<IValidator<WorkerDetailsRequest>, WorkerDetailsRequestValidator>();
            services.AddScoped<IValidator<WorkerLoginRequest>, WorkerLoginRequestValidator>();
            services.AddScoped<IValidator<WorkerControlBookSheetRequest>, WorkerControlBookSheetRequestValidator>();
            services.AddScoped<IValidator<OtpVerificationRequest>, OtpVerificationRequestValidator>();
            services.AddScoped<IValidator<GenerateOtpRequest>, GenerateOtpRequestValidator>();
            services.AddScoped<IValidator<WorkerControlBookSheetDetailsRequest>, ControlBookSheetDetailsRequestValidator>();


            return services;
        }
    }
}
