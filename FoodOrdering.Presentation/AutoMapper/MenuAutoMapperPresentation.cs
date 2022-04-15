using AutoMapper;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Application.Dtos.Menu;
using FoodOrdering.Presentation.ViewModels.Dish;
using FoodOrdering.Presentation.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation
{
    public class MenuAutoMapperPresentation : Profile
    {
        public MenuAutoMapperPresentation()
        {
            CreateMap<AddMenuViewModel, AddMenuDto>();
            CreateMap<AddDishToMenuViewModel, AddDishToMenuDto>();
            CreateMap<EditMenuViewModel, EditMenuDto>();
            CreateMap<GotMenuDto, GotMenuViewModel>();
            CreateMap<GotAllMenusDto, GotAllMenusViewModel>();
            CreateMap<GotMenuDetailsDto, GotMenuDetailsViewModel>();
            CreateMap<GotDishesDto, GotDishesViewModel>();
        }
    }
}
