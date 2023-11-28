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

    public GetIspitivanjeResponseVM? GetIspitivanje(int id)
    {
        GetIspitivanjeResponseVM? ispitivanje = _ispitivanjeRepo.GetIspitivanje(id);

        return ispitivanje;
    }

    public async Task<List<GetAllIspitivanjeResponseVM>> GetAllIspitivanje()
    {
        return (await _ispitivanjeRepo.GetAllIspitivanje())!;
    }

    public async Task<int> PostIspitivanje(PostIspitivanjeVM novoIspitivanje)
    {
        return await _ispitivanjeRepo.PostIspitivanje(novoIspitivanje);
    }
    public async Task<int> IzbrisiIspitivanjeById(int id)
    {
        return await _ispitivanjeRepo.IzbrisiIspitivanjeById(id);
    }
}