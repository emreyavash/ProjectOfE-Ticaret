using AutoMapper;
using ProjectOfE_Ticaret.DataAccess.Abstract;
using ProjectOfE_Ticaret.DataAccess.ContextDb;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.EntityFramework
{
    public class EfProductDal : EfEntityRepository<Product, ETicaretDbContext>, IProductDal
    {
        private readonly IMapper _mapper;

        public EfProductDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductInfoDTO GetProductById(int id)
        {
            using (ETicaretDbContext context = new ETicaretDbContext())
            {
                var result = from productInfo in context.Products
                             join category in context.Categorys
                             on productInfo.CategoryId equals category.Id
                             join user in context.Users
                             on productInfo.UserId equals user.Id
                             where productInfo.Id == id
                             select new ProductInfoDTO
                             {
                                 Id = productInfo.Id,
                                 Description = productInfo.Description,
                                 Price = productInfo.Price,
                                 ProductName = productInfo.ProductName,
                                 Status = productInfo.Status,
                                 StockAmount = productInfo.StockAmount,
                                 Category = _mapper.Map<CategoryDTO>(category),
                                 Seller = _mapper.Map<UserInfoDTO>(user)

                             };
                return result.FirstOrDefault();
            }
        }

        public List<ProductInfoDTO> GetProductsByCategoryId(int categoryId)
        {
            using (ETicaretDbContext context = new ETicaretDbContext())
            {
                var result = from productInfo in context.Products
                             join category in context.Categorys
                             on productInfo.CategoryId equals category.Id
                             join user in context.Users
                             on productInfo.UserId equals user.Id
                             where productInfo.CategoryId == categoryId
                             select new ProductInfoDTO
                             {
                                 Id = productInfo.Id,
                                 Description = productInfo.Description,
                                 Price = productInfo.Price,
                                 ProductName = productInfo.ProductName,
                                 Status = productInfo.Status,
                                 StockAmount = productInfo.StockAmount,
                                 Category = _mapper.Map<CategoryDTO>(category),
                                 Seller = _mapper.Map<UserInfoDTO>(user)

                             };
                return result.ToList();
            }
        }

        public List<ProductInfoDTO> GetProductsByUserId(int userId)
        {
            using (ETicaretDbContext context = new ETicaretDbContext())
            {
                var result = from productInfo in context.Products
                             join category in context.Categorys
                             on productInfo.CategoryId equals category.Id
                             join user in context.Users
                             on productInfo.UserId equals user.Id
                             where productInfo.UserId == userId
                             select new ProductInfoDTO
                             {
                                 Id = productInfo.Id,
                                 Description = productInfo.Description,
                                 Price = productInfo.Price,
                                 ProductName = productInfo.ProductName,
                                 Status = productInfo.Status,
                                 StockAmount = productInfo.StockAmount,
                                 Category = _mapper.Map<CategoryDTO>(category),
                                 Seller = _mapper.Map<UserInfoDTO>(user)

                             };
                return result.ToList();
            }
        }

        public List<ProductInfoDTO> GetProductsInfo()
        {
            using (ETicaretDbContext context = new ETicaretDbContext())
            {
                var result = from productInfo in context.Products
                             join category in context.Categorys
                             on productInfo.CategoryId equals category.Id
                             join user in context.Users
                             on productInfo.UserId equals user.Id                     
                             select new ProductInfoDTO
                             {
                                 Id = productInfo.Id,
                                 Description = productInfo.Description,
                                 Price = productInfo.Price,
                                 ProductName = productInfo.ProductName,
                                 Status = productInfo.Status,
                                 StockAmount = productInfo.StockAmount,
                                 Category = _mapper.Map<CategoryDTO>(category),
                                 Seller = _mapper.Map<UserInfoDTO>(user)
                                 
                             };
                return result.ToList();
            }
        }
    }
}
