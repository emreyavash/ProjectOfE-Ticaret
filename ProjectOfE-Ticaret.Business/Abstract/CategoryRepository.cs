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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryDal _category;
        private readonly IMapper _mapper;

        public CategoryRepository(ICategoryDal category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        public VoidResult AddCategory(CategoryDTO category)
        {
           var voidResult = new VoidResult();
            var categoryDTO = _mapper.Map<Category>(category);
            var isAdded = _category.Add(categoryDTO);
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

        public VoidResult DeleteCategory(CategoryDTO category)
        {
            var voidResult = new VoidResult();
            var categoryDTO = _mapper.Map<Category>(category);
            var isDeleted = _category.Add(categoryDTO);
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

        public DataResult<List<CategoryDTO>> GetAllCategories()
        {
            var dataResult = new DataResult<List<CategoryDTO>>();
            var categoryContext = _category.GetAll();
            var result = _mapper.Map<List<CategoryDTO>>(categoryContext);
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

        public DataResult<CategoryDTO> GetCategoryById(int id)
        {
           var dataResult = new DataResult<CategoryDTO>();
            var categoryContext = _category.Get(x=>x.Id == id);
            var result = _mapper.Map<CategoryDTO>(categoryContext);

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

        public VoidResult UpdateCategory(CategoryDTO category)
        {
            var voidResult = new VoidResult();
            var categoryDTO = _mapper.Map<Category>(category);
            var isUpdated = _category.Update(categoryDTO);
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
