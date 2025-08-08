using AutoMapper;
using localClinic.Dtos;
using localClinic.Models;
namespace localClinic
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            // Add your mapping configurations here
            // For example:
            // CreateMap<SourceModel, DestinationModel>();

            CreateMap<BookingDto, Booking>();
            CreateMap<AdminDto, Admin>();
            CreateMap<PatientDto, Patient>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<ReceiptDto, Receipt>();
            CreateMap<ScheduleDto, Schedule>();
            CreateMap<TimeDto, Time>(); 

        }
    }
    
}
