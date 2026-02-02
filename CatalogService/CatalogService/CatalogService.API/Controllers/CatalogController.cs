using CatalogService.Business.Inteface;
using CatalogService.CQRS.Commands;
using CatalogService.Model.Model;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ICategoryCommandService _catCmd;
        private readonly IProductCommandService _prodCmd;
        private readonly ICatalogQueryService _query;

        public CatalogController(ICategoryCommandService catCmd, IProductCommandService prodCmd,ICatalogQueryService query)
        {
            _catCmd = catCmd;
            _prodCmd = prodCmd;
            _query = query;
        }


        // WRITE
        [HttpPost("category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand cmd)
            => Ok(await _catCmd.CreateAsync(cmd));

        // READ
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _query.GetCategories();
            if (response.Any())
                return Ok(response);
            return NoContent();
        }

        [HttpGet("productByParentCategory/{id}")]
        public async Task<IActionResult> GetProducts(Guid id)
        {
            var response = await _query.GetProductsByCategory(id);
            if (response.Any())
                return Ok(response);
            return NoContent();
        }  

        [HttpPost("subCategory")]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryCommand cmd)
        {
            await _catCmd.CreateSubCategoryAsync(cmd);
            return Created();
        }

        [HttpGet("subCategories")]
        public async Task<IActionResult> GetSubCategories()
        {
            var response = await _query.GetSubCategories();
            if (response.Any())
                return Ok(response);
            return NoContent();
        }

        [HttpGet("productBySubCategories")]
        public async Task<IActionResult> GetProductBySubCategories(int id)
        {
            var response = await _query.GetProductBySubCategories(id);
            if (response.Any())
                return Ok(response);
            return NoContent();
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand cmd)
            => Ok(await _prodCmd.CreateAsync(cmd));

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            
            var response = await _query.GetProductById(id);
            if (response != null)
                return Ok(response);
             return NoContent();
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand cmd)
        {
             var response  = await _prodCmd.UpdateAsync(cmd);
            if(response != null)
                return Ok(response);
            return NoContent();
        }
     

        [HttpPost("reserveStock")]
        public async Task<IActionResult> ReserveBulk(List<StockUpdateModel> items)
        {
                return Ok(await _catCmd.ReserveOrFail(items));
        }
    }

}
