using Base;
using BusinessLayer.Abstract;
using EntityLayer.Dto.Product;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpraOdev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var deger = _productService.GetList();
            return Ok(deger);
        }
        [HttpGet("GetAllInclude")]
        public IActionResult GetAllInclude()
        {
            var deger = _productService.GetAllWithCategory();
            return Ok(deger);
        }
        [HttpGet("GetByIdInclude")]
        public IActionResult GetByIdInclude(int id)
        {
            var deger = _productService.GetByIdWithCategory(id);
            return Ok(deger);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var deger = _productService.GetByID(id);
            return Ok(deger);
        }
        [HttpPost]
        public ApiResponse Post([FromBody] ProductRequest product)
        {
            var result = _productService.Add(product);
            return result;
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            bool result = _productService.Delete(id);
            return Ok(result);
        }
        [HttpPut]
        public ApiResponse Update([FromBody] ProductRequest product)
        {
            var result = _productService.Update(product);
            return result;
        }
    }
}
