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
    public class CategorysController : ControllerBase
    {
        private readonly DataContext _context;

        public CategorysController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var item = new List<Category>();
            foreach (var items in await _context.Categories.ToListAsync())
                item.Add(new Category(items.Id, items.Name));
            return item;
        }

        // GET: api/Categorys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            return new Category(categoryEntity.Id, categoryEntity.Name);
        }

        // PUT: api/Categorys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryEntity(int id, CategoryUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var categoryEntity = await _context.Categories.FindAsync(model.Id);
            categoryEntity.Name = model.Name;

            _context.Entry(categoryEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryEntityExists(id))
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

        // POST: api/Categorys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategoryEntity(CategoryCreateModel model)
        {
            var categoryEntity = new CategoryEntity(model.Name);
            _context.Categories.Add(categoryEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryEntity", new { id = categoryEntity.Id }, new Category(categoryEntity.Id, categoryEntity.Name));
        }

        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryEntityExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
