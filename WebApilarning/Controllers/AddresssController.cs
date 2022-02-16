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
    public class AddresssController : ControllerBase
    {
        private readonly DataContext _context;

        public AddresssController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Addresss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var items = new List<Address>();
            foreach (var item in await _context.Addresses.ToListAsync())
                items.Add(new Address(item.Id, item.StreetName, item.PostalCode, item.Country, item.City));
            return items ;
        }

        // GET: api/Addresss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressEntity(int id)
        {
            var addressEntity = await _context.Addresses.FindAsync(id);

            if (addressEntity == null)
            {
                return NotFound();
            }

            return new Address(addressEntity.Id, addressEntity.StreetName, addressEntity.PostalCode,addressEntity.Country, addressEntity.City);
        }

        // PUT: api/Addresss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressEntity(int id, AddressUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var addressEntity = await _context.Addresses.FindAsync(model.Id);
            addressEntity.StreetName = model.StreetName;
            addressEntity.PostalCode = model.PostalCode;
            addressEntity.Country = model.Country;
            addressEntity.City = model.City;

            _context.Entry(addressEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressEntityExists(id))
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

        // POST: api/Addresss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddressEntity(AddressCreateModel model)
        {
            var addressEntity = new AddressEntity(model.StreetName,model.PostalCode,model.Country,model.City);
            _context.Addresses.Add(addressEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressEntity", new { id = addressEntity.Id }, new Address(addressEntity.Id,addressEntity.StreetName,addressEntity.PostalCode,addressEntity.Country,addressEntity.City));
        }

        // DELETE: api/Addresss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressEntity(int id)
        {
            var addressEntity = await _context.Addresses.FindAsync(id);
            if (addressEntity == null)
            {
                return NotFound();
            }
            addressEntity.StreetName = "";
            addressEntity.PostalCode = "";
            addressEntity.Country = "";
            addressEntity.City = "";
            
            _context.Entry(addressEntity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressEntityExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
