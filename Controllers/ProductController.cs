using Microsoft.AspNetCore.Mvc;
using AutoGlass;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository productRepository;

        public ProductController(IProductRepository context)
        {
            productRepository = context;            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(productRepository.Get());
        }
     

        [HttpGet("{code}")]
        public ActionResult<Product> GetProductByCode(int code)
        {
            var currentProduct = productRepository.GetProductByCode(code);
            if (currentProduct != null) return Ok(currentProduct);
            
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            if(!ModelState.IsValid) return BadRequest("Data incomplete");
            
            //Validate manufaturing date < validity date
            if(product.ManufacturingDate < product.ValidityDate)
            {
                await productRepository.Insert(product);
                return Ok();
            }
            var result = "Manufacturing date can't be bigger than Validity date";
            return new ObjectResult(result) {StatusCode = 400};
            
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<Product>> Put(int code, [FromBody] Product product)
        {
            if(!ModelState.IsValid) return BadRequest("Data incomplete");

            if(product.ManufacturingDate < product.ValidityDate)
            {
                var currentProduct = productRepository.GetProductByCode(code);
                if(currentProduct == null) return NotFound();

                await productRepository.Update(code,product);
                return NoContent();
            }
            var result = "Manufacturing date can't be bigger than Validity date";
            return new ObjectResult(result) {StatusCode = 400};
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteProductByCode(int code)
        {
            var currentProduct = productRepository.GetProductByCode(code);
            if(currentProduct == null) return NotFound();
            await productRepository.DeleteByCode(code);
            return Ok();
        }
    }
