using DTO;
using Economy.Service;
using Microsoft.AspNetCore.Mvc;

namespace Economy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {

        private IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _brandService.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var brand = _brandService.GetById(id);
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Brand model)
        {
            _brandService.Create(model);
            return Ok(new { message = "Brand created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Brand model)
        {
            _brandService.Update(id, model);
            return Ok(new { message = "Brand updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandService.Delete(id);
            return Ok(new { message = "Brand deleted" });
        }
    }
}
