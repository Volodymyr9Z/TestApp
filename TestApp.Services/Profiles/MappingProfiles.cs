using AutoMapper;
using TestApp.Domain.DTO_s.AccountDTO;
using TestApp.Domain.Entities;

namespace TestApp.Services.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Account, CheckAccountDTO>()
                .ForMember(dto => dto.Description, a => a.MapFrom(a => a.Incident.Description))
                .ForMember(dto => dto.Name, a => a.MapFrom(a =>a.Name))
                .ReverseMap();

            CreateMap<Contact, CheckAccountDTO>()
                .ForMember(dto => dto.FirstName, a => a.MapFrom(c => c.FirstName))
                .ForMember(dto => dto.Email, a => a.MapFrom(c => c.Email))
                .ForMember(dto => dto.LastName, a => a.MapFrom(c => c.LastName))
                .ReverseMap();

            CreateMap<Incident, CheckAccountDTO>()
                .ForMember(dto => dto.Description, i => i.MapFrom(c => c.Description))
                .ReverseMap(); 

            CreateMap<Contact , ResultDTO>()
                .ForMember(dto => dto.FirstName, a => a.MapFrom(c => c.FirstName))
                .ForMember(dto => dto.Email, a => a.MapFrom(c => c.Email))
                .ForMember(dto => dto.LastName, a => a.MapFrom(c => c.LastName))
                .ForMember(dto =>dto.Description, a=>a.MapFrom(c => c.Account.Incident.Description))
                .ForMember(dto => dto.IncidentId, a => a.MapFrom(c => c.Account.Incident.Name))
                .ForMember(dto => dto.AccountName, a => a.MapFrom(c => c.Account.Name))
                .ReverseMap();

            CreateMap<CheckAccountDTO,Account >()
                .ForMember(dto => dto.Id , c => c.Ignore() )
                .ReverseMap();
            CreateMap<CheckAccountDTO, Contact>()
                .ForMember(dto => dto.Id, c => c.Ignore())
                .ReverseMap();

        }
    }
}
