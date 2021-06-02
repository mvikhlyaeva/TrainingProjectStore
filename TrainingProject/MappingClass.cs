using AutoMapper;
using TrainingProject.Domain;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StoreDepartment, StoreDepartmentDomainModel>();
            CreateMap<StoreDepartmentDomainModel, StoreDepartment>();

            CreateMap<Stand, StandDomainModelForGet>();
            CreateMap<StandDomainModelForGet, Stand>();

            CreateMap<Stand, StandDomainModel>();
            CreateMap<StandDomainModel, Stand>();

            CreateMap<Stand, StandDomainModelForPost>();
            CreateMap<StandDomainModelForPost, Stand>();

            CreateMap<Cell, CellDomainModelForPost>();
            CreateMap<CellDomainModelForPost, Cell>();

            CreateMap<Cell, CellDomainModelForPut>();
            CreateMap<CellDomainModelForPut, Cell>();

            CreateMap<Product, ProductDomainModelForPost>();
            CreateMap<ProductDomainModelForPost, Product>();

            CreateMap<Product, ProductDomainModelForGet>();
            CreateMap<ProductDomainModelForGet, Product>();

            /*CreateMap<List<StandDomainModelForGet>, List<Stand>>();
            CreateMap<List<Stand>, List<StandDomainModelForGet>>();

            CreateMap<List<StandDomainModelForPost>, List<Stand>>();
            CreateMap<List<Stand>, List<StandDomainModelForPost>>();

            CreateMap<List<StandDomainModelForPost>, IOrderedQueryable<StandDomainModelForPost>>();
            CreateMap<IOrderedQueryable<StandDomainModelForPost>, List<StandDomainModelForPost>>();

            CreateMap<List<StandDomainModelForPost>, IOrderedEnumerable<StandDomainModelForPost>>();
            CreateMap<IOrderedEnumerable<StandDomainModelForPost>, List<StandDomainModelForPost>>();

            CreateMap<List<Stand>, IOrderedQueryable<StandDomainModelForPost>>();
            CreateMap<IOrderedQueryable<StandDomainModelForPost>, List<Stand>>();*/
        }
    }
}