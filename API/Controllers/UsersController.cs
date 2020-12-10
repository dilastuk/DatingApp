using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class UsersController : BaseApiController
    {
        //Controller per la classe USERS
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        // https://localhost:5001/api/users/2
        //Restituisce la lista di tutti gli utenti
        [HttpGet]
        [AllowAnonymous]

        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            return await _context.Users.ToListAsync();
            
        }

        // https://localhost:5001/api/users
        //Cerca utente per id =>int
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            return await _context.Users.FindAsync(id);
            
        }
    }
}