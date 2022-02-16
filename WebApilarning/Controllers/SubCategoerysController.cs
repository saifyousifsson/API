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
    public class SubCategoerysController : ControllerBase
    {
        private readonly DataContext _context;

        public SubCategoerysController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SubCategoerys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategoeries()
        {    var item = new List<SubCategory>();
            foreach (var items in await _context.SubCategoeries.Include(x => x.Category).ToListAsync())
                item.Add(new SubCategory(items.Id, items.Name,items.CategoryId));
            return item;
        }

        // GET: api/SubCategoerys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategoeryEntity(int id)
        {
            var subCategoeryEntity = await _context.SubCategoeries.FindAsync(id);

            if (subCategoeryEntity == null)
            {
                return NotFound();
            }

            return new SubCategory(subCategoeryEntity.Id,subCategoeryEntity.Name,subCategoeryEntity.CategoryId);
        }

        // PUT: api/SubCategoerys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategoeryEntity(int id, SubCategoryUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var subCategoeryEntity = await _context.SubCategoeries.FindAsync(model.Id);
            subCategoeryEntity.Name = model.Name;
            _context.Entry(subCategoeryEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoeryEntityExists(id))
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

        // POST: api/SubCategoerys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategoeryEntity(SubCategoryCreateModel model)
        {
           
                var subCategoeryEntity = new SubCategoryEntity(model.Name,model.CategoeryId);
            _context.SubCategoeries.Add(subCategoeryEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCategoeryEntity", new { id = subCategoeryEntity.Id }, new SubCategory(subCategoeryEntity.Id,subCategoeryEntity.Name,subCategoeryEntity.CategoryId));
        }

        // DELETE: api/SubCategoerys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategoeryEntity(int id)
        {
            var subCategoeryEntity = await _context.SubCategoeries.FindAsync(id);
            if (subCategoeryEntity == null)
            {
                return NotFound();
            }

            _context.SubCategoeries.Remove(subCategoeryEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubCategoeryEntityExists(int id)
        {
            return _context.SubCategoeries.Any(e => e.Id == id);
        }
    }
}
