using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.DTOs
{
    public class ProductInfoDTO :IDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockAmount { get; set; }
        public CategoryDTO Category { get; set; }
        public UserInfoDTO Seller { get; set; }
        public bool Status { get; set; }
    }
}
