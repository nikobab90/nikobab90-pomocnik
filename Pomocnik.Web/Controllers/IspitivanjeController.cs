using Microsoft.AspNetCore.Mvc;
using Pomocnik.BAL;
using Pomocnik.Model;

namespace Pomocnik.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitivanjeController : ControllerBase
{
    private readonly ILogger<IspitivanjeController> _logger;
    private readonly IspitivanjeService _ispitivanjeService;
    public IspitivanjeController(ILogger<IspitivanjeController> logger,
        IspitivanjeService ispitivanjeService)
    {
        _logger = logger;
        _ispitivanjeService = ispitivanjeService;
    }

    [HttpGet("{id}")]
    public ActionResult GetIspitivanje([FromRoute] int id)
    {
        try
        {
            GetIspitivanjeResponseVM? ispitivanje = _ispitivanjeService.GetIspitivanje(id);

            if (ispitivanje is not null)
            {
                return Ok(ispitivanje);
            }
            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
    
    [HttpGet("Listasvihispitivanja")]
    public async Task<ActionResult<List<GetAllIspitivanjeResponseVM>>> GetAllIspitivanje()
    {
        var ispitivanje = await _ispitivanjeService.GetAllIspitivanje();
            return Ok(ispitivanje);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostIspitivanje([FromBody] PostIspitivanjeVM ispitivanje)
    {
        try
        {
            int insertedId = await _ispitivanjeService.PostIspitivanje(ispitivanje);
            return CreatedAtAction(nameof(PostIspitivanje), new { id = insertedId }, ispitivanje);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Došlo je do greške prilikom umetanja Tvrtke: " + ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> IzbrisiIspitivanjeById(int id)
    {
        try
        {
            int affectedRows = await _ispitivanjeService.IzbrisiIspitivanjeById(id);

            if (affectedRows > 0)
            {
                return Ok("Ispitivanje je uspješno izbrisano.");
            }
            else
            {
                return NotFound("Ispitivanje nije pronađeno ili je već izbrisano.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Došlo je do greške prilikom brisanja Ispitivanja: " + ex.Message);
        }
    }
}
