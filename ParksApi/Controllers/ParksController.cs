using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksClient.Models;

namespace ParksClient.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksClientContext _db;

    public ParksController(ParksClientContext db)
    {
        _db=db;
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    //Get api/parks
    [HttpGet]
    public async Task<List<Park>> GetParks(string name, int id, bool parkNational)
    {
        IQueryable<Park> query = _db.Parks.AsQueryable();

        if (name != null)
        {
          query= query.Where(e => e.ParkName == name);
        }
        
        // if (parkNational == true)
        // {
        //   query = query.Where(e => e.ParkNational == parkNational);
        // } else 
        // {
        //   query = query.Where(e => e.ParkNational == false);
        // }

      return await query.ToListAsync();
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

    //Post: api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> PostPark(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPark), new {id = park.ParkId}, park);
    }

    //Put: api/parks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPark(int id, Park park)
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

    // DELETE: api/parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
          return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
