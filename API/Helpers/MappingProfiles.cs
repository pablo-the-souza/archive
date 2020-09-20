using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Policy, PolicyToReturnDTO>()
                .ForMember(d => d.Box, o => o.MapFrom(s => s.Box.Id));
        }
    }
}