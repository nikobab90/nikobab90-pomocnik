using Pomocnik.DAL;
using Pomocnik.Model;

namespace Pomocnik.BAL;

public class ServisiranjeService
{
    private readonly ServisiranjeRepo _servisiranjeRepo;
    
    public ServisiranjeService (ServisiranjeRepo servisiranjeRepo)
    {
        _servisiranjeRepo = servisiranjeRepo;
    }
// dohvati servisiranje po id-u
    public GetServisiranjeResponseVM? GetServisiranje(int id)
    {
        GetServisiranjeResponseVM? servisiranje = _servisiranjeRepo.GetServisiranje(id);
        
        return servisiranje;
    }
    
    // dohvati SVA servisiranja
    public async Task<List<GetAllServisiranjeResponseVM>> GetAllServisiranje()
    {
        return await _servisiranjeRepo.GetAllServisiranje();
    }
    
    // dodaj novo Servisiranje
    public async Task<int> PostServisiranje(PostServisiranjeVM novoServisiranje)
    {
        // Pretvori GetIspitivanjeResponseVM u instancu Ispitivanje entiteta 
        var servisiranjeEntity = new PostServisiranjeVM
        {
            SerijskiBroj = novoServisiranje.SerijskiBroj,
            TvornickiBroj = novoServisiranje.TvornickiBroj,
            DatumOd = novoServisiranje.DatumOd,
            DatumDo = novoServisiranje.DatumDo,
            Cijena = novoServisiranje.Cijena,
            Pdv = novoServisiranje.Pdv,
            TvrtkaId = novoServisiranje.TvrtkaId,
            VrstaServisiranjaId = novoServisiranje.VrstaServisiranjaId,
            LokacijaId = novoServisiranje.LokacijaId,
            ZaposlenikId = novoServisiranje.ZaposlenikId
        };

        // Dodaj ispitivanje u bazu podataka
        await _servisiranjeRepo.PostServisiranje(servisiranjeEntity);
        return novoServisiranje.Id;
    }
}