using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VictorVentralProduct.Application.Products.Dtos;
using VictorVentralProduct.Application.Products.Exceptions;
using VictorVentralProduct.Application.Products.Interfaces;

namespace VictorVentralProduct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet("/GetAllProducts")]
        public async Task<ActionResult<List<GetProduct>>> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProductsAsync());
            }
            catch (ProductEmptyListException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("/GetProductById/{id:int}")]
        public async Task<ActionResult<GetProduct>> GetProductById(int id)
        {
            try
            {
                return Ok(await _productService.GetProductByIdAsync(id));
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost("/AddProduct")]
        public async Task<ActionResult<CreatedProductResponse>> AddProductAsync(CreateProduct newProduct)
        {
            try
            {

                return Ok(await _productService.AddProductAsync(newProduct));
            }
            catch (InvalidProductException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/UpdateProductById/{id:int}")]
        public async Task<ActionResult<UpdatedProductResponse>> UpdateProductById(int id, CreateProduct newProduct)
        {
            try
            {
                return Ok(await _productService.UpdateProductAsync(id, newProduct));
            }
            catch (UpdatingProductFailedException ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpDelete("/DeleteProductById/{id:int}")]
        public async Task<ActionResult<DeletedProductResponse>> DeleteProductById(int id)
        {
            try
            {
                return Ok(await _productService.DeleteProductAsync(id));
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
