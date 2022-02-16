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
    public class OrderessController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderessController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Orderess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderes>>> GetOrderes()
        {   var items= new List<Orderes>();
            foreach (var item in await _context.Orderes.Include(x => x.OrderLines).Include(x=>x.User).ToListAsync()) 
            {
                if (item.User != null)
                    items.Add(new Orderes(item.Id, item.Created, item.AntalProducts, item.Status, item.ProductId, item.UserId, new User(item.User.Id, item.User.FirstName, item.User.LastName, item.User.Email)));
                else
                    items.Add(new Orderes(item.Id, item.Created, item.AntalProducts, item.Status, item.ProductId, item.UserId));



            }
            return items ;
        }

        // GET: api/Orderess/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderes>> GetOrderesEntity(int id)
        {  
            var orderesEntity = await _context.Orderes.Include(x => x.OrderLines).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            if (orderesEntity == null)
            {
                return NotFound();
            }
           if (orderesEntity.User != null)
                return new Orderes(orderesEntity.Id, orderesEntity.Created, orderesEntity.AntalProducts, orderesEntity.Status, orderesEntity.ProductId, orderesEntity.UserId, new User(orderesEntity.User.Id, orderesEntity.User.FirstName, orderesEntity.User.LastName, orderesEntity.User.Email));
            else
                return new Orderes(orderesEntity.Id,orderesEntity.Created,orderesEntity.AntalProducts,orderesEntity.Status,orderesEntity.ProductId,orderesEntity.UserId);



        }
        
        // PUT: api/Orderess/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderesEntity(int id, OrderesUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var orderesEntity = await _context.Orderes.FindAsync(model.Id);
                    
            orderesEntity.AntalProducts=model.AntalProducts;
            orderesEntity.Status=model.Status;

            _context.Entry(orderesEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderesEntityExists(id))
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

        // POST: api/Orderess
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orderes>> PostOrderesEntity(OrderesCreateModel model)
        {
          if (!await _context.Users.AnyAsync(x => x.Id == model.UserId))
               return BadRequest();
            var orderesEntity = new OrderesEntity(model.Created , model.AntalProducts,model.Status,model.ProductId,model.UserId);
            _context.Orderes.Add(orderesEntity);
            await _context.SaveChangesAsync();
            var _orderesEntity = await _context.Orderes.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == orderesEntity.Id);
            
            return CreatedAtAction("GetOrderesEntity", new { id = orderesEntity.Id }, new Orderes(_orderesEntity.Id, _orderesEntity.Created, _orderesEntity.AntalProducts, _orderesEntity.Status, _orderesEntity.ProductId, _orderesEntity.UserId));

        }

        // DELETE: api/Orderess/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderesEntity(int id)
        {
            var orderesEntity = await _context.Orderes.FindAsync(id);
            if (orderesEntity == null)
            {
                return NotFound();
            }
            orderesEntity.User.FirstName = "";
            orderesEntity.User.LastName = "";
            orderesEntity.User.Email = "";
            orderesEntity.User.Address.StreetName = "";
            orderesEntity.User.Address.PostalCode = "";
            orderesEntity.User.Address.Country = "";
            orderesEntity.User.Address.City = "";

            _context.Entry(orderesEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderesEntityExists(int id)
        {
            return _context.Orderes.Any(e => e.Id == id);
        }
    }
}
