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
using WebApilarning.Models.Forms;

namespace WebApilarning.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = new List<User>();   
            foreach (var user in await _context.Users.Include(X=>X.Address).ToListAsync())
                users.Add(new User(user.Id, user.FirstName, user.LastName, user.Email, user.Address.StreetName, user.Address.PostalCode, user.Address.Country, user.Address.City ));
            return users;
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserEntity(int id)
        {
            var user = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x=>x.Id==id);

            if (user == null)
            {
                return NotFound();
            }

            return new User(user.Id, user.FirstName, user.LastName, user.Email, user.Address.StreetName, user.Address.PostalCode, user.Address.Country, user.Address.City);
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEntity(int id, UserUpdateForm model)

        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var userEntity = await _context.Users.FindAsync(model.Id);
            if (userEntity == null)
                return NotFound();
             userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.Email = model.Email;
            userEntity.PassWord = model.Password;
            userEntity.Address = new AddressEntity {PostalCode=model.PostalCode, Country=model.Country, StreetName=model.StreetName};

            _context.Entry(userEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUserEntity(UserRegistrationForm model)
        {
            if (await _context.Users.AnyAsync(x=>x.Email==model.Email))
                return Conflict();
            UserEntity userEntity;
            var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x=>x.StreetName==model.StreetName&& x.PostalCode==model.PostalCode);
            if (addressEntity == null)

            userEntity= new UserEntity(model.FirstName,model.LastName,model.Email, model.Password, DateTime.Now,DateTime.Now, new AddressEntity(model.StreetName,model.PostalCode, model.City,model.Country));
            else
              userEntity=  new UserEntity(model.FirstName, model.LastName, model.Email, model.Password, DateTime.Now, DateTime.Now,addressEntity.Id);
            _context.Add(userEntity);
            await _context.SaveChangesAsync();
            var user = new User(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.Email, userEntity.Address.StreetName, userEntity.Address.PostalCode, userEntity.Address.Country, userEntity.Address.City);
            return CreatedAtAction("GetUserEntity", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEntity(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            userEntity.FirstName = "";
            userEntity.LastName = "";
            userEntity.Email = "";
            userEntity.PassWord = "";
         
             _context.Entry(userEntity).State = EntityState.Modified;
           
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
