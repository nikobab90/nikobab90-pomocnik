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
    [HttpGet("Popis svih zaposlenika")]
    public ActionResult<List<GetAllZaposleniciResponseVM?>> GetAllZaposlenici()
    {
        try
        {
            List<GetAllZaposleniciResponseVM?> zaposlenici = _zaposleniciService.GetAllZaposlenici();

            if (zaposlenici.Count > 0)
            {
                return Ok(zaposlenici);
            }

            return NotFound("Nema dostupnih zaposlenika.");
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
}