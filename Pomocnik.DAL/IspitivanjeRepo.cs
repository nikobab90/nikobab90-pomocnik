using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Pomocnik.Model;

namespace Pomocnik.DAL;

public class IspitivanjeRepo
{
    private readonly IConfiguration _configuration;

    public IspitivanjeRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // dohvati ispitivanje po id-u
    public GetIspitivanjeResponseVM? GetIspitivanje(int id)
    {
        using IDbConnection db = GetConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

        return db.QueryFirstOrDefault<GetIspitivanjeResponseVM>("GetIspitivanje", parameters,
            commandType: CommandType.StoredProcedure);
    }
    // dohvati sva ispitivanja
    public async Task<List<GetAllIspitivanjeResponseVM?>> GetAllIspitivanje()
    {
        using IDbConnection db = GetConnection();

        IEnumerable<GetAllIspitivanjeResponseVM> ispitivanja = await db.QueryAsync<GetAllIspitivanjeResponseVM>
            ("GetAllIspitivanje", commandType: CommandType.StoredProcedure);

        return ispitivanja.ToList()!;
    }
    
    // dodaj novo ispitivanje
    public async Task<int> PostIspitivanje(PostIspitivanjeVM ispitivanje)
    {
        using IDbConnection db = GetConnection();
        var result = await db.QueryAsync<int>("PostIspitivanje",
            new
            {
                ispitivanje.SerijskiBroj,
                ispitivanje.TvornickiBroj,
                ispitivanje.DatumOd,
                ispitivanje.DatumDo,
                ispitivanje.Cijena,
                ispitivanje.Pdv,
                ispitivanje.TvrtkaId,
                ispitivanje.VrstaIspitivanjaId,
                ispitivanje.LokacijaId,
                ispitivanje.ZaposlenikId
            },
            commandType: CommandType.StoredProcedure);
        return result.First();
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}

