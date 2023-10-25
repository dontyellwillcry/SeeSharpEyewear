using SeeSharpEyewear.Models;
using SeeSharpEyewear.Services;
using Microsoft.AspNetCore.Mvc;

namespace SeeSharpEyewear.Controllers;

[ApiController]
[Route("[controller]")]
public class ShadesController : ControllerBase
// http://localhost:5168/Shades
{
    public ShadesController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Shades>> GetAll() =>
    ShadesService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Shades> Get(int id)
    {
        var shades = ShadesService.Get(id);

        if (shades == null)
            return NotFound();

        return shades;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Shades shades)
    {
        ShadesService.Add(shades);
        return CreatedAtAction(nameof(Get), new { id = shades.Id }, shades);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Shades shades)
    {
        if (id != shades.Id)
            return BadRequest();

        var existingShades= ShadesService.Get(id);
        if (existingShades is null)
            return NotFound();

        ShadesService.Update(shades);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var shades = ShadesService.Get(id);

        if (shades is null)
            return NotFound();

       ShadesService.Delete(id);

        return NoContent();
    }
}

// Test push