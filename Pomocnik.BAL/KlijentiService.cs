﻿using Pomocnik.DAL;
using Pomocnik.Model;

namespace Pomocnik.BAL;

public class KlijentiService
{
    private readonly KlijentiRepo _klijentiRepo;

    public KlijentiService (KlijentiRepo klijentiRepo)
    {
        _klijentiRepo = klijentiRepo;
    }
    // dohvati tvrtku po id-u
    public GetKlijentResponseVM? GetTvrtka(int id)
    {
        GetKlijentResponseVM? klijent = _klijentiRepo.GetTvrtka(id);

        return klijent;
    }

    // dohvati sve tvrtke
    public async Task<List<GetAllKlijentiResponseVM>> GetAllTvrtka()
    {
        return await _klijentiRepo.GetAllTvrtka();
    }
}