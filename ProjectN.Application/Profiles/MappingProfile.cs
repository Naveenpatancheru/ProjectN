using AutoMapper;
using ProjectN.Application.Features.Colleges.Queries.GetCollegesList;
using ProjectN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<College, CollegeListVm>().ReverseMap();
        }
    }
}
