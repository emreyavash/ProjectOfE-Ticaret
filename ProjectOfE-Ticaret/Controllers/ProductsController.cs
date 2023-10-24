using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.Infrastructure.Interface;

namespace ProjectOfE_Ticaret.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Seller")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ProductsGetAll")]
        [AllowAnonymous]
        public IActionResult ProductsGetAll()
        {
            var result = _repository.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("ProductGetById")]
        [AllowAnonymous]
        public IActionResult ProductGetById(int id)
        {
            var result = _repository.GetProductById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("ProductsGetByCategoryId")]
        [AllowAnonymous]
        public IActionResult ProductsGetByCategoryId(int categoryId)
        {
            var result = _repository.GetProductsByCategoryId(categoryId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("ProductsGetByUserId")]
        [AllowAnonymous]
        public IActionResult ProductsGetByUserId(int userId)
        {
            var result = _repository.GetProductsByUserId(userId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("ProductAdd")]
        public IActionResult ProductAdd(ProductDTO product)
        {
            var result = _repository.Add(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("ProductDelete")]
        public IActionResult ProductDelete(ProductDTO product)
        {
            var result = _repository.Delete(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("ProductUpdate")]
        public IActionResult ProductUpdate(ProductDTO product)
        {
            var result = _repository.Update(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
