using DTO;
using Economy.Service;
using Microsoft.AspNetCore.Mvc;

namespace Economy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            _categoryService.Create(model);
            return Ok(new { message = "Category created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category model)
        {
            _categoryService.Update(id, model);
            return Ok(new { message = "Category updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok(new { message = "Category deleted" });
        }
    }
}
