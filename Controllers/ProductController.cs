using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGEFExample.Data;
using PGEFExample.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductsContext _context;

    public ProductController(ProductsContext context)
    {
        _context = context;
    }

    [HttpGet("get-products")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("get-products-by-subcategory/{subcategory}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsBySubCategory(string subcategory)
    {
        // Belirtilen alt kategorideki ürünleri çekiyoruz
        var products = await _context.Products
            .Where(p => p.subCategory == subcategory)
            .ToListAsync();

        // Eğer ürün bulunamadıysa 404 (Not Found) döner
        if (products == null || products.Count == 0)
        {
            return NotFound(new { message = "Bu alt kategoriye ait ürün bulunamadı." });
        }

        // Bulunan ürünleri döndürür
        return Ok(products);
    }

    [HttpGet("get-product/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost("save-product")]
    public async Task<ActionResult<Product>> SaveProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
    }

    [HttpPut("update-product/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.ID)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("delete-product/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.ID == id);
    }
    
}