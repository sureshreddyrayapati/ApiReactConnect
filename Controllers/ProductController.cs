using Microsoft.AspNetCore.Mvc;
using ReactApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ReactApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ReactApiDbContext _context;

        public ProductsController(ReactApiDbContext context)
        {
            _context = context;
        }

        // 🔹 1. Get All Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        // 🔹 2. Get Product by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return product;
        }

        // 🔹 3. Add New Product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = product.Prodct_Id }, product);
        }

        // 🔹 4. Update Product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updated)
        {
            if (id != updated.Prodct_Id)
                return BadRequest();

            var existing = await _context.Products.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Product_Name = updated.Product_Name;
            existing.Product_price = updated.Product_price;
            existing.Product_expityDate = updated.Product_expityDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 5. Delete Product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
