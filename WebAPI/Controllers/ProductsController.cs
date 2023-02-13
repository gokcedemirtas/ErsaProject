using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productservice;
        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = _productservice.GetAll();
            return result is not null ? Ok(result) : BadRequest("işlem başarısız");
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int productId)
        {
            var result = _productservice.GetById(productId);
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productservice.Add(product);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productservice.Delete(product);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productservice.Update(product);
            return Ok(result);
        }
    }
}
