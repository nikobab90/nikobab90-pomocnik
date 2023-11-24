using Pomocnik.DAL;
using Pomocnik.Model;

namespace Pomocnik.BAL;

public class IspitivanjeService
{
    private readonly IspitivanjeRepo _ispitivanjeRepo;

    public IspitivanjeService(IspitivanjeRepo ispitivanjeRepo)
    {
        _ispitivanjeRepo = ispitivanjeRepo;
    }
    // dohvati ispitivanje po id-u
    public GetIspitivanjeResponseVM? GetIspitivanje(int id)
    {
        GetIspitivanjeResponseVM? ispitivanje = _ispitivanjeRepo.GetIspitivanje(id);

        return ispitivanje;
    }
    
    //dohvati sva ispitivanja
    public List<GetAllIspitivanjeResponseVM?> GetAllIspitivanje()
    {
        List<GetAllIspitivanjeResponseVM?> ispitivanja = _ispitivanjeRepo.GetAllIspitivanje();

        return ispitivanja;
    }
    
// dodaj novo ispitivanje
    public void PostIspitivanje(PostIspitivanjeVM novoIspitivanje)
    {
        // Pretvori GetIspitivanjeResponseVM u instancu Ispitivanje entiteta 
        var ispitivanjeEntity = new PostIspitivanjeVM
        {
            SerijskiBroj = novoIspitivanje.SerijskiBroj,
            TvornickiBroj = novoIspitivanje.TvornickiBroj,
            DatumOd = novoIspitivanje.DatumOd,
            DatumDo = novoIspitivanje.DatumDo,
            Cijena = novoIspitivanje.Cijena,
            Pdv = novoIspitivanje.Pdv,
            TvrtkaId = novoIspitivanje.TvrtkaId,
            VrstaIspitivanjaId = novoIspitivanje.VrstaIspitivanjaId,
            LokacijaId = novoIspitivanje.LokacijaId,
            ZaposlenikId = novoIspitivanje.ZaposlenikId
        };

        // Dodaj ispitivanje u bazu podataka
        _ispitivanjeRepo.PostIspitivanje(ispitivanjeEntity);
    }
}