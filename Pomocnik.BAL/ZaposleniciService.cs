using Pomocnik.DAL;
using Pomocnik.Model;

namespace Pomocnik.BAL;

public class ZaposleniciService
{
    private readonly ZaposleniciRepo _zaposleniciRepo;

    public ZaposleniciService (ZaposleniciRepo zaposleniciRepo)
    {
        _zaposleniciRepo = zaposleniciRepo;
    }
    
    // dohvati zaposlenika po id-u
    public GetZaposlenikResponseVM? GetZaposlenik(int id)
    {
        GetZaposlenikResponseVM? zaposlenik = _zaposleniciRepo.GetZaposlenik(id);

        return zaposlenik;
    }
    
    // dohvati sve zaposlenike
    public async Task<List<GetAllZaposleniciResponseVM>> GetAllZaposlenici()
    {
        return await _zaposleniciRepo.GetAllZaposlenici();
    }
    
    // dodaj novog Zaposlenika
    public async Task<int> PostZaposlenici(PostZaposleniciVM noviZaposlenik)
    {
    
        // Pretvori GetIspitivanjeResponseVM u instancu Ispitivanje entiteta 
        var zaposleniciEntity = new PostZaposleniciVM
        {
            Ime = noviZaposlenik.Ime,
            Prezime = noviZaposlenik.Prezime,
            Oib = noviZaposlenik.Oib,
            TvrtkaId = noviZaposlenik.TvrtkaId,
            KontaktPodatciId = noviZaposlenik.KontaktPodatciId
        };

        // Dodaj ispitivanje u bazu podataka
        return await _zaposleniciRepo.PostZaposlenici(zaposleniciEntity);
    }
}