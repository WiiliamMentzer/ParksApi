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
  [Route("api/[controller]")]
  [ApiController]
  public class ParkController : ControllerBase
  {
    private readonly ParksClientContext _db;

    public ParkController(ParksClientContext db)
    {
        _db=db;
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
    
    //Get: api/parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
          return NotFound();
      }

      return park;
    }

    //Get api/parks
    [HttpGet]
    public async Task<List<Park>> Get(string name, int id)
    {
        IQueryable<Park> query = _db.Parks.AsQueryable();

        if (name != null)
        {
            query= query.Where(e => e.ParkName == name);
        }       

      return await query.ToListAsync();
    }

    //Post: api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPark), new {id = park.ParkId}, park);
    }

    //Put: api/parks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
        if (id != park.ParkId)
        {
            return BadRequest();
        }

        _db.Entry(park).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ParkExists(id))
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
