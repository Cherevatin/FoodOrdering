using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Presentation.ViewModels.Basket
{
    public class GotBasketViewModel
    {
        public Guid CustomerId { get; set; }

        public List<Guid> Items { get; set; }
    }
}
