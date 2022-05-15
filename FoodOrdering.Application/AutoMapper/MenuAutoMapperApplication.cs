using AutoMapper;

using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class MenuAutoMapperApplication : Profile
    {
        public MenuAutoMapperApplication()
        {
            CreateMap<Menu, GetAllMenusDto>();
            CreateMap<Dish, GetAllMenusDto.Dish>()
                .ForMember(m => m.WeightMeasurementUnit, opt => opt.MapFrom(p => p.Weight.MesurementUnit.ToString()))
                .ForMember(m => m.WeightValue, opt => opt.MapFrom(p => p.Weight.Value))
                .ForMember(m => m.Calories, opt => opt.MapFrom(p => p.Nutrients.Calories))
                .ForMember(m => m.Carbohydrates, opt => opt.MapFrom(p => p.Nutrients.Carbohydrates))
                .ForMember(m => m.Fats, opt => opt.MapFrom(p => p.Nutrients.Fats))
                .ForMember(m => m.Proteins, opt => opt.MapFrom(p => p.Nutrients.Proteins));

            CreateMap<Menu, GetMenuDto>();
            CreateMap<Dish, GetMenuDto.Dish>()
                .ForMember(m => m.WeightMeasurementUnit, opt => opt.MapFrom(p => p.Weight.MesurementUnit.ToString()))
                .ForMember(m => m.WeightValue, opt => opt.MapFrom(p => p.Weight.Value))
                .ForMember(m => m.Calories, opt => opt.MapFrom(p => p.Nutrients.Calories))
                .ForMember(m => m.Carbohydrates, opt => opt.MapFrom(p => p.Nutrients.Carbohydrates))
                .ForMember(m => m.Fats, opt => opt.MapFrom(p => p.Nutrients.Fats))
                .ForMember(m => m.Proteins, opt => opt.MapFrom(p => p.Nutrients.Proteins));
        }
    }
}
