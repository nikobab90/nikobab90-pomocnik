/*

using Microsoft.AspNetCore.Mvc;
using Pomocnik.BAL;
using Pomocnik.Model;

namespace Pomocnik.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class DokumentiController : ControllerBase
{
    private readonly ILogger<DokumentiController> _logger;
    private readonly DokumentiService _dokumentiService;

    public DokumentiController(ILogger<DokumentiController> logger,
        DokumentiService dokumentiService)
    {
        _logger = logger;
        _dokumentiService = dokumentiService;
    }

    [HttpGet("{id}")]
    public ActionResult GetDokumenti([FromRoute] int id)
    {
        try
        {
            GetDokumentResponseVM? dokument = _dokumentiService.GetDokumenti(id);

            if (dokument is not null)
            {
                return Ok(dokument);
            }

            return NotFound();
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
}

*/