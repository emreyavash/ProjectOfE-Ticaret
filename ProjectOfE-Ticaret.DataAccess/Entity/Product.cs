using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Entity
{
    public class Product : IEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockAmount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
}
