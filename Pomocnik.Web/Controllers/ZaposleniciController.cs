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

    // dohvati zaposlenike po id-u
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

    // dohvati sve zaposlenike
    [HttpGet("popisSvihzaposlenika")]
    public async Task<ActionResult<List<GetAllZaposleniciResponseVM>>> GetAllZaposlenici()
    {
        var zaposleni = await _zaposleniciService.GetAllZaposlenici();
        return Ok(zaposleni);
    }
}
