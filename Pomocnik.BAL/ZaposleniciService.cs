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
    
    public GetZaposlenikResponseVM? GetZaposlenik(int id)
    {
        GetZaposlenikResponseVM? zaposlenik = _zaposleniciRepo.GetZaposlenik(id);

        return zaposlenik;
    }
   
    public async Task<List<GetAllZaposleniciResponseVM>> GetAllZaposlenici()
    {
        return await _zaposleniciRepo.GetAllZaposlenici();
    }
   
    public async Task<int> PostZaposlenici(PostZaposleniciVM noviZaposlenik)
    {
        return await _zaposleniciRepo.PostZaposlenici(noviZaposlenik);
    }
    public async Task<int> IzbrisiaposlenikaById(int id)
    {
        return await _zaposleniciRepo.IzbrisiaposlenikaById(id);
    }
}