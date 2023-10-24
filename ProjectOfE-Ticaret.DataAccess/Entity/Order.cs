using ProjectOfE_Ticaret.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Entity
{
    public class Order : IEntity
    {
        public int UserId { get; set; }
        public int BasketId { get; set; }
        public int OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }

    }

   
}
