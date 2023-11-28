using Microsoft.AspNetCore.Mvc;
using Pomocnik.BAL;
using Pomocnik.Model;

namespace Pomocnik.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ServisiranjeController : ControllerBase
{
    private readonly ILogger<ServisiranjeController> _logger;
    private readonly ServisiranjeService _servisiranjeService;
    public ServisiranjeController(ILogger<ServisiranjeController> logger,
        ServisiranjeService servisiranjeService)
    {
        _logger = logger;
        _servisiranjeService = servisiranjeService;
    }
    
    [HttpGet("{id}")]
    public ActionResult GetServisiranje([FromRoute] int id)
    {
        try
        {
            GetServisiranjeResponseVM? servisiranje = _servisiranjeService.GetServisiranje(id);

            if (servisiranje is not null)
            {
                return Ok(servisiranje);
            }
            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
    
    [HttpGet("listaSvihServisiranja")]
    public async Task<ActionResult<List<GetServisiranjeResponseVM>>> GetAllServisiranje()
    {
        var servisi =await _servisiranjeService.GetAllServisiranje();
        return Ok(servisi);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostServisiranje([FromBody] PostServisiranjeVM servisiranje)
    {
        try
        {
            int insertedId = await _servisiranjeService.PostServisiranje(servisiranje);
            return CreatedAtAction(nameof(PostServisiranje), new { id = insertedId }, servisiranje);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Došlo je do greške prilikom umetanja Tvrtke: " + ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> IzbrisiServisiranje(int id)
    {
        try
        {
            int affectedRows = await _servisiranjeService.IzbrisiServisiranjeById(id);

            if (affectedRows > 0)
            {
                return Ok("Servisiranje je uspješno izbrisano.");
            }
            else
            {
                return NotFound("Servisni nalog nije pronađen ili je već izbrisan.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Došlo je do greške prilikom brisanja Servisnog naloga: " + ex.Message);
        }
    }
}