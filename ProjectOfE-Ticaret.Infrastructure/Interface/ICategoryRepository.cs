using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Infrastructure.Interface
{
    public interface ICategoryRepository
    {
        VoidResult AddCategory(CategoryDTO category);
        VoidResult DeleteCategory(CategoryDTO category);
        VoidResult UpdateCategory(CategoryDTO category);
        DataResult<List<CategoryDTO>> GetAllCategories();
        DataResult<CategoryDTO> GetCategoryById(int id);
    }
}
