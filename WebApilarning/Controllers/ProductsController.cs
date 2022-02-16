using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApilarning;
using WebApilarning.Filters;
using WebApilarning.Models;
using WebApilarning.Models.Entites;

namespace WebApilarning.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        { var item = new List<Product>();
            foreach (var items in await _context.Products.Include(x => x.SubCategory).ToListAsync())
            {
                if (items.SubCategory != null)
                    item.Add(new Product(items.Id, items.Artikelnummer, items.Name, items.Description, items.Price, items.AntalProducts,items.SubCategoryId));
               else
                    item.Add(new Product(items.Id, items.Artikelnummer, items.Name, items.Description, items.Price, items.AntalProducts, new SubCategory(items.SubCategory.Id, items.SubCategory.Name)));
            }

            return item;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductEntity(int id)
        {
            var productEntity = await _context.Products.Include(x=>x.SubCategory).FirstOrDefaultAsync(x => x.Id == id);

            if (productEntity == null)
            {
                return NotFound();
            }
            if (productEntity.SubCategory != null)


            return new Product(productEntity.Id,productEntity.Artikelnummer,productEntity.Name,productEntity.Description,productEntity.Price,productEntity.AntalProducts,productEntity.SubCategoryId);
            else
            return new Product(productEntity.Id, productEntity.Artikelnummer, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.AntalProducts, new SubCategory(productEntity.SubCategory.Id, productEntity.SubCategory.Name));

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProduktUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var productEntity = await _context.Products.FindAsync(model.Id);
            productEntity.Artikelnummer = model.Artikelnummer;
            productEntity.Description = model.Description;
            productEntity.Price = model.Price;
            productEntity.AntalProducts = model.AntalProducts;
        
            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProductEntity(ProduktCreateModel model)
        {
            if (!await _context.SubCategoeries.AnyAsync(x => x.Id == model.SubCategoryId))
                return BadRequest();
            var productEntity = new ProductEntity(model.Artikelnummer, model.Name, model.Description, model.Price, model.Created, model.Modified, model.AntalProducts, model.SubCategoryId);
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            var _productEntity = await _context.Products.Include(x => x.SubCategory).FirstOrDefaultAsync(x => x.Id == productEntity.Id);

            return CreatedAtAction("GetProductEntity", new { id = productEntity.Id }, new Product(_productEntity.Id, _productEntity.Artikelnummer,
                _productEntity.Name, _productEntity.Description, _productEntity.Price, _productEntity.AntalProducts, _productEntity.SubCategoryId));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
