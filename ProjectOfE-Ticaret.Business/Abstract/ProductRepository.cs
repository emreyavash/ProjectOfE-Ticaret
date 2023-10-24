using AutoMapper;
using ProjectOfE_Ticaret.Business.Constants;
using ProjectOfE_Ticaret.DataAccess.Abstract;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.DataAccess.Results;
using ProjectOfE_Ticaret.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Business.Abstract
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDal _repository;
        private readonly ICategoryDal _categoryDal;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public ProductRepository(IProductDal repository, ICategoryDal categoryDal, IUserDal userDal, IMapper mapper)
        {
            _repository = repository;
            _categoryDal = categoryDal;
            _userDal = userDal;
            _mapper = mapper;
        }

        public VoidResult Add(ProductDTO entity)
        {
            var productDTO = _mapper.Map<Product>(entity);

           var isAdded= _repository.Add(productDTO);
            var voidResult = new VoidResult();

            if (!isAdded)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotAdded;
                return voidResult;
            }
            voidResult.Success = true;
            voidResult.Message = Messages.Added;
            return voidResult;
        }

        public VoidResult Delete(ProductDTO entity)
        {
            var productDTO = _mapper.Map<Product>(entity);

            var isDeleted = _repository.Delete(productDTO);
            var voidResult = new VoidResult();

            if (!isDeleted)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotDeleted;
                return voidResult;
            }
            voidResult.Success = true;
            voidResult.Message = Messages.Deleted;
            return voidResult;
        }

        public DataResult<List<ProductInfoDTO>> GetAll()
        {
            var result = _repository.GetProductsInfo();
            var dataResult = new DataResult<List<ProductInfoDTO>>();
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }

            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            dataResult.Data = result;
            return dataResult;
        }

        public DataResult<ProductInfoDTO> GetProductById(int id)
        {
            var dataResult = new DataResult<ProductInfoDTO>();

            var result = _repository.GetProductById(id);

            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }

            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            dataResult.Data = result;
            return dataResult;
        }

        public DataResult<List<ProductInfoDTO>> GetProductsByCategoryId(int categoryId)
        {
            var dataResult = new DataResult<List<ProductInfoDTO>>();
            var productCategory = _repository.GetProductsByCategoryId(categoryId);

            if (productCategory == null)
            {
                dataResult.Success = true;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Data = productCategory;
            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            return dataResult;

        }

        public DataResult<List<ProductInfoDTO>> GetProductsByUserId(int userId)
        {
            var result = _repository.GetProductsByCategoryId(userId);

            var dataResult = new DataResult<List<ProductInfoDTO>>();
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }

            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            dataResult.Data = result;
            return dataResult;
        }

        public VoidResult Update(ProductDTO entity)
        {
            var productDTO = _mapper.Map<Product>(entity);
            var isUpdated= _repository.Update(productDTO);
            var voidResult = new VoidResult();

            if (!isUpdated)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotUpdated;
                return voidResult;
            }
            voidResult.Success = true;
            voidResult.Message = Messages.Updated;
            return voidResult;
        }

       
    }
}
