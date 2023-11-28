using Pomocnik.DAL;
using Pomocnik.Model;

namespace Pomocnik.BAL;

public class ServisiranjeService
{
    private readonly ServisiranjeRepo _servisiranjeRepo;

    public ServisiranjeService(ServisiranjeRepo servisiranjeRepo)
    {
        _servisiranjeRepo = servisiranjeRepo;
    }

    public GetServisiranjeResponseVM? GetServisiranje(int id)
    {
        GetServisiranjeResponseVM? servisiranje = _servisiranjeRepo.GetServisiranje(id);

        return servisiranje;
    }

    public async Task<List<GetAllServisiranjeResponseVM>> GetAllServisiranje()
    {
        return await _servisiranjeRepo.GetAllServisiranje();
    }

    public async Task<int> PostServisiranje(PostServisiranjeVM novoServisiranje)
    {
        return await _servisiranjeRepo.PostServisiranje(novoServisiranje);
    }
    
    public async Task<int> IzbrisiServisiranjeById(int id)
    {
        return await _servisiranjeRepo.IzbrisiServisiranjeById(id);
    }
}