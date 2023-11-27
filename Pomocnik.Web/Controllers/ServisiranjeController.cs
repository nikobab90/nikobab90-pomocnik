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
// dohvati servisiranja po id-u
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
    
    //dohvati SVA servisiranja
    [HttpGet("listaSvihServisiranja")]
    public async Task<ActionResult<List<GetServisiranjeResponseVM>>> GetAllServisiranje()
    {
        var servisi =await _servisiranjeService.GetAllServisiranje();
        return Ok(servisi);
    }
}