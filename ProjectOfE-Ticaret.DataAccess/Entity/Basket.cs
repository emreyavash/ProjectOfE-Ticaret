using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Entity
{
    public class Basket : IEntity
    {
        public int UserId { get; set; }
        public List<Product> ProductItems { get; set; }
        public decimal TotalBasketPrice { get; set; }

    }
}
