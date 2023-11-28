using Microsoft.AspNetCore.Mvc;
using Pomocnik.BAL;
using Pomocnik.Model;

namespace Pomocnik.Web.Controllers;

[ApiController]
[Route("[controller]")]

public class ZaposleniciController : ControllerBase
{
    private readonly ILogger<ZaposleniciController> _logger;
    private readonly ZaposleniciService _zaposleniciService;
    public ZaposleniciController(ILogger<ZaposleniciController> logger,
        ZaposleniciService zaposleniciService)
    {
        _logger = logger;
        _zaposleniciService = zaposleniciService;
    }
    
    [HttpGet("{id}")]
    public ActionResult GetZaposlenik([FromRoute] int id)
    {
        try
        {
            GetZaposlenikResponseVM? zaposlenik = _zaposleniciService.GetZaposlenik(id);

            if (zaposlenik is not null)
            {
                return Ok(zaposlenik);
            }
            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
    
    [HttpGet("popisSvihzaposlenika")]
    public async Task<ActionResult<List<GetAllZaposleniciResponseVM>>> GetAllZaposlenici()
    {
        var zaposleni = await _zaposleniciService.GetAllZaposlenici();
        return Ok(zaposleni);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostZaposlenici([FromBody] PostZaposleniciVM zaposlenik)
    {
        try
        {
            int insertedId = await _zaposleniciService.PostZaposlenici(zaposlenik);
            return CreatedAtAction(nameof(PostZaposlenici), new { id = insertedId }, zaposlenik);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Došlo je do greške prilikom umetanja zaposlenika: " + ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteZaposlenika(int id)
    {
        try
        {
            int affectedRows = await _zaposleniciService.IzbrisiaposlenikaById(id);

            if (affectedRows > 0)
            {
                return Ok("Zaposlenik je uspješno izbrisan.");
            }
            else
            {
                return NotFound("Zaposlenik nije pronađen ili je već izbrisan.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Došlo je do greške prilikom brisanja Zaposlenika: " + ex.Message);
        }
    }
}
