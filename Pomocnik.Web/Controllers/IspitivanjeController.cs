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
// dohvati ispitivanje po id-u
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
    
    // dohvati sva ispitivanja
    [HttpGet("Lista svih ispitivanja")]
    public ActionResult<List<GetAllIspitivanjeResponseVM>> GetAllIspitivanje()
    {
        try
        {
            List<GetAllIspitivanjeResponseVM?> ispitivanja = _ispitivanjeService.GetAllIspitivanje();

            if (ispitivanja.Count > 0)
            {
                return Ok(ispitivanja);
            }

            return NotFound("Nema dostupnih ispitivanja.");
        }
        catch
        {
            return StatusCode(500, "Greška pri pozivu servisa");
        }
    }
    
    // dodaj novo ispitivanje
    [HttpPost("{id}")]
        public ActionResult PostIspitivanje([FromBody] PostIspitivanjeVM request)
        {
            try
            {
                if (request.Id > 0)  
                    //if (request.Id != null && request.Id.Any())
                {
                    // Pretvori GettIspitivanjeRequestVM u instancu GetIspitivanjeResponseVM
                    PostIspitivanjeVM novoIspitivanje = new PostIspitivanjeVM
                    {
                        SerijskiBroj = request.SerijskiBroj,
                        TvornickiBroj = request.TvornickiBroj,
                        DatumOd = request.DatumOd,
                        DatumDo = request.DatumDo,
                        Cijena = request.Cijena,
                        Pdv = request.Pdv,
                        TvrtkaId = request.TvrtkaId,
                        VrstaIspitivanjaId = request.VrstaIspitivanjaId,
                        LokacijaId = request.LokacijaId,
                        ZaposlenikId = request.ZaposlenikId
                    };

                    // Pozovi servis da dodas novo ispitivanje
                    _ispitivanjeService.PostIspitivanje(novoIspitivanje);

                    // Vrati novo ispitivanje sa statusom 201 Created
                    return CreatedAtAction(nameof(PostIspitivanje), new { id = novoIspitivanje.Id }, novoIspitivanje);
                    
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Došlo je do greške prilikom obrade zahtjeva: " + ex.Message);
            }
        }
    }
