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
}