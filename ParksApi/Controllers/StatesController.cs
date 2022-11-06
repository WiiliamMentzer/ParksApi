using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksClient.Models;

namespace ParksClient.Controllers
{
    [Route(api/[controller])]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly ParksClientContext _db;

        public StatesController(ParksClientContext db)
        {
            _db=db;
        }

        private bool StateExists(int id)
        {
            return _sb.States.Any(e =>e.StateId == id);
        }

        //Get: api/states/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _db.States.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

            //Get api/states
        [HttpGet]
        public async Task<List<State>> Get(string title, string topic)
        {
            IQueryable<State> query = _db.States.AsQueryable();

            if (title != null)
            {
                query= query.Where(entry => entry.StateTitle == title);
            }

            if (topic != null)
            {
                query= query.Where(entry => entry.StateTopic == topic);
            }

        return await query.ToListAsync();
        }

            //Put: api/States/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, State state)
    {
        if (id != state.StateId)
        {
            return BadRequest();
        }

        _db.Entry(state).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
            {
            if (!StateExists(id))
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
    }
}