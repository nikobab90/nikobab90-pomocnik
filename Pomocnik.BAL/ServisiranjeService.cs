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
    public List<GetAllServisiranjeResponseVM?> GetAllServisiranje()
    {
        List<GetAllServisiranjeResponseVM?> servisiranja = _servisiranjeRepo.GetAllServisiranje();

        return servisiranja;
    }
}