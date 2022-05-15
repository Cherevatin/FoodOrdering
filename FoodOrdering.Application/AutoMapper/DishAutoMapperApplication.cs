using AutoMapper;

using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Domain.Aggregates.DishAggregate;

namespace FoodOrdering.Application.AutoMapper
{
    public class DishAutoMapperApplication : Profile
    {
        public DishAutoMapperApplication()
        {
            CreateMap<Dish, GetAllDishesDto>()
                .ForMember(m => m.WeightMeasurementUnit, opt => opt.MapFrom(p => p.Weight.MesurementUnit.ToString()))
                .ForMember(m => m.WeightValue, opt => opt.MapFrom(p => p.Weight.Value))
                .ForMember(m => m.Calories, opt => opt.MapFrom(p => p.Nutrients.Calories))
                .ForMember(m => m.Carbohydrates, opt => opt.MapFrom(p => p.Nutrients.Carbohydrates))
                .ForMember(m => m.Fats, opt => opt.MapFrom(p => p.Nutrients.Fats))
                .ForMember(m => m.Proteins, opt => opt.MapFrom(p => p.Nutrients.Proteins));

            CreateMap<Dish, GetDishDto>()
                .ForMember(m => m.WeightMeasurementUnit, opt => opt.MapFrom(p => p.Weight.MesurementUnit.ToString()))
                .ForMember(m => m.WeightValue, opt => opt.MapFrom(p => p.Weight.Value))
                .ForMember(m => m.Calories, opt => opt.MapFrom(p => p.Nutrients.Calories))
                .ForMember(m => m.Carbohydrates, opt => opt.MapFrom(p => p.Nutrients.Carbohydrates))
                .ForMember(m => m.Fats, opt => opt.MapFrom(p => p.Nutrients.Fats))
                .ForMember(m => m.Proteins, opt => opt.MapFrom(p => p.Nutrients.Proteins));

        }
    }
}
