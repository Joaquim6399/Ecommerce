using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        

    }
}
