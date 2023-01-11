using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public string NomorMeja { get; set; } = String.Empty;
        public Menus? Menus { get; set; }
        public int MenusId { get; set; }
        public string NoOrder { get; set; } = String.Empty;
    }
}
