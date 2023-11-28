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
    
    public GetIspitivanjeResponseVM? GetIspitivanje(int id)
    {
        using IDbConnection db = GetConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

        return db.QueryFirstOrDefault<GetIspitivanjeResponseVM>("GetIspitivanje", parameters,
            commandType: CommandType.StoredProcedure);
    }
    
    public async Task<List<GetAllIspitivanjeResponseVM?>> GetAllIspitivanje()
    {
        using IDbConnection db = GetConnection();

        IEnumerable<GetAllIspitivanjeResponseVM> ispitivanja = await db.QueryAsync<GetAllIspitivanjeResponseVM>
            ("GetAllIspitivanje", commandType: CommandType.StoredProcedure);

        return ispitivanja.ToList()!;
    }
    
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
    public async Task<int> IzbrisiIspitivanjeById(int id)
    {
        using IDbConnection db = GetConnection();
    
        var parameters = new
        {
            Id = id
        };
        return await db.ExecuteAsync("IzbrisiIspitivanjeById", parameters, commandType: CommandType.StoredProcedure);
    }
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}

