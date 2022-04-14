using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.DishMenu
{
    public class AddDishToMenuDto
    {
        public Guid MenuId { get; set; }

        public List<Guid> DishesId { get; set; }
    }
}
