using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApilarning;
using WebApilarning.Models;
using WebApilarning.Models.Entites;

namespace WebApilarning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderLinesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrderLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> GetOrderLines()
        { 
            var item = new List<OrderLine>();
            foreach (var items in await _context.OrderLines.Include(x=>x.Orderes).Include(x=>x.Product).ToListAsync())
              
                {
                if (items.Orderes != null)
                   item.Add(new OrderLine(items.OrderesId,items.ProductId, new Orderes(items.Orderes.Id, items.Orderes.Created, items.Orderes.AntalProducts, items.Orderes.Status, items.Orderes.ProductId, items.Orderes.UserId)));
                else
                  item.Add(new OrderLine( items.OrderesId, items.ProductId));
                            
                }
            return item;
        }

  

        // POST: api/OrderLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderLine>> PostOrderLineEntity(OrderlineCreateModel model)
        {
            if (!await _context.Orderes.AnyAsync(x => x.Id == model.OrderesId))
                return NotFound();
                
                var orederLineEntity = new OrderLineEntity (model.OrderesId,model.ProductId);
           
                _context.OrderLines.Add(orederLineEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!OrderLineEntityExists(orederLineEntity.OrderesId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var orderLineEntity = await _context.OrderLines.FindAsync(model.OrderesId);
            if (orderLineEntity != null)
            {
             //   _context.Entry(orderLineEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: api/OrderLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderLineEntity(int id)
        {
            var orderLineEntity = await _context.OrderLines.FindAsync(id);
            if (orderLineEntity == null)
            {
                return Conflict();
            }

            _context.OrderLines.Remove(orderLineEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderLineEntityExists(int id)
        {
            return _context.OrderLines.Any(e => e.OrderesId == id);
        }
    }
}
