using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Menu
{
    public class AddMenuDto
    {
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

        public List<Guid> Dishes { get; set; }
    }
}
