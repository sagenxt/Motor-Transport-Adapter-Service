using AutoMapper;
using Motor.Transport.Adapter.Models.DTOs.Response;

namespace Motor.Transport.Adapter.Service.Mappers
{
    public class OtpResponseMapper : Profile
    {
        public OtpResponseMapper()
        {
            CreateMap<OtpVerificationResponse, GenerateOtpResponse>()
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));

        }
    }
}
