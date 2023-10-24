using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.Infrastructure.Interface;

namespace ProjectOfE_Ticaret.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryRepository.GetAllCategories();
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _categoryRepository.GetCategoryById(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CategoryDTO category) 
        {
            var result = _categoryRepository.AddCategory(category);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(CategoryDTO category)
        {
            var result = _categoryRepository.DeleteCategory(category);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(CategoryDTO category)
        {
            var result = _categoryRepository.UpdateCategory(category);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
