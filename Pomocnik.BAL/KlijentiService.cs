using Pomocnik.DAL;
using Pomocnik.Model;

namespace Pomocnik.BAL;

public class KlijentiService
{
    private readonly KlijentiRepo _klijentiRepo;

    public KlijentiService (KlijentiRepo klijentiRepo)
    {
        _klijentiRepo = klijentiRepo;
    }
    
    public GetKlijentResponseVM? GetTvrtka(int id)
    {
        GetKlijentResponseVM? klijent = _klijentiRepo.GetTvrtka(id);

        return klijent;
    }

    public async Task<List<GetAllKlijentiResponseVM>> GetAllTvrtka()
    {
        return await _klijentiRepo.GetAllTvrtka();
    }
    
    public async Task<int> PostTvrtka(PostKlijentiVM noviKlijent)
    {
        return await _klijentiRepo.PostTvrtka(noviKlijent);
    }
    public async Task<int> IzbrisiTvrtkuById(int id)
    {
        return await _klijentiRepo.IzbrisiTvrtkuById(id);
    }
}