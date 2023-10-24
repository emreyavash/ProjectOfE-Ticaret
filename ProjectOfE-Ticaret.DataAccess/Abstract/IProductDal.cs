using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductInfoDTO> GetProductsInfo();
        ProductInfoDTO GetProductById(int id);
        List<ProductInfoDTO> GetProductsByCategoryId(int categoryId);
        List<ProductInfoDTO> GetProductsByUserId(int userId);

    }
}
