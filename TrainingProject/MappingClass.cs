using AutoMapper;
using System.Collections.Generic;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StoreDepartment, StoreDepartmentDomainModel>();
            CreateMap<StoreDepartmentDomainModel, StoreDepartment>();
            CreateMap< Stand, StandDomainModel >();
            CreateMap<StandDomainModel, Stand>();
            CreateMap<List <StandDomainModel>,List<Stand>>();
            CreateMap<List<Stand>, List<StandDomainModel>>();
        }
    }
}
