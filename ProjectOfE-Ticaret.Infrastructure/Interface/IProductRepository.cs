using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.DataAccess.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Infrastructure.Interface
{
    public interface IProductRepository
    {
        VoidResult Add(ProductDTO entity);
        VoidResult Delete(ProductDTO entity);
        VoidResult Update(ProductDTO entity);
        DataResult<List<ProductInfoDTO>> GetProductsByCategoryId(int categoryId);
        DataResult<List<ProductInfoDTO>> GetAll();
        DataResult<ProductInfoDTO> GetProductById(int id);
        DataResult<List<ProductInfoDTO>> GetProductsByUserId(int userId);
    }
}
