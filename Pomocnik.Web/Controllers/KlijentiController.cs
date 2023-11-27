using Microsoft.AspNetCore.Mvc;
using Pomocnik.BAL;
using Pomocnik.Model;

namespace Pomocnik.Web.Controllers;

[ApiController]
[Route("[controller]")]

public class KlijentiController : ControllerBase
{
    private readonly ILogger<KlijentiController> _logger;
    private readonly KlijentiService _klijentiService;
    
    public KlijentiController(ILogger<KlijentiController> logger,
        KlijentiService klijentiService)
    {
        _logger = logger;
        _klijentiService = klijentiService;
    }

    [HttpGet("{id}")]
    public ActionResult GetTvrtka([FromRoute] int id)
    {
        try
        {
            GetKlijentResponseVM? klijent = _klijentiService.GetTvrtka(id);

            if (klijent is not null)
            {
                return Ok(klijent);
            }

            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
    
    // dohvati sve tvrtke
    [HttpGet("popisSvihklijenata")]
    public async Task<ActionResult<List<GetAllKlijentiResponseVM>>> GetAllTvrtka()
    {
        var tvrtke = await _klijentiService.GetAllTvrtka();
        return Ok(tvrtke);
    }
}