using AutoMapper;
using FoodOrdering.Application.Dtos.Dish;
using FoodOrdering.Application.Dtos.DishMenu;
using FoodOrdering.Presentation.ViewModels.Dish;
using FoodOrdering.Presentation.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation
{
    public class PresentationAutoMapper : Profile
    {
        public PresentationAutoMapper()
        {
            CreateMap<AddDishViewModel, DishDto>();
            CreateMap<EditDishViewModel, DishDto>();
            CreateMap<DishDto, GetDishViewModel>();
            CreateMap<GetAllDishesDto, GetAllDishesViewModel>();
            

            CreateMap<AddMenuViewModel, MenuDto>();
            CreateMap<EditMenuViewModel, MenuDto>();
            CreateMap<MenuDto, GetMenuViewModel>();
            CreateMap<GetAllMenusDto, GetAllMenusViewModel>();
            CreateMap<AddDishToMenuViewModel, AddDishToMenuDto>();
        }
    }
}
