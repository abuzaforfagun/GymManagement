using AutoMapper;
using GymManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GymManagement.Domain.Models.Presistance;

namespace GymManagement.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberResourceForUpdate>().ReverseMap()
                .ForMember(m => m.JoiningDate, config => config.Ignore())
                .ForMember(m => m.RessignDate, config => config.Ignore());
            CreateMap<Member, MemberResourceForSave>().ReverseMap();

        }
    }
}
