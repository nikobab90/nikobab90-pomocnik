using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Pomocnik.Model;

namespace Pomocnik.DAL;

public class ZaposleniciRepo
{
    private readonly IConfiguration _configuration;
    public ZaposleniciRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public GetZaposlenikResponseVM? GetZaposlenik(int id)
    {
        using IDbConnection db = GetConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        
        return db.QueryFirstOrDefault<GetZaposlenikResponseVM>("Getzaposlenik", parameters, commandType: CommandType.StoredProcedure);
    }
    
    public async Task<List<GetAllZaposleniciResponseVM>> GetAllZaposlenici()
    {
        using IDbConnection db = GetConnection();
        
        IEnumerable<GetAllZaposleniciResponseVM> zaposlenici =await db.QueryAsync<GetAllZaposleniciResponseVM>
            ("GetAllZaposlenici", commandType: CommandType.StoredProcedure);

        return zaposlenici.ToList();
    }
    
    public async Task<int> PostZaposlenici(PostZaposleniciVM zaposlenik)
    {
        using IDbConnection db = GetConnection();
        var result = await db.QueryAsync<int>("PostZaposlenik",
            new
            {
                zaposlenik.Ime,
                zaposlenik.Prezime,
                zaposlenik.Oib,
                zaposlenik.TvrtkaId,
                zaposlenik.KontaktPodatciId
                
            },
            commandType: CommandType.StoredProcedure);
        return result.First();
    }
    
    public async Task<int> IzbrisiaposlenikaById(int id)
    {
        using IDbConnection db = GetConnection();
    
        var parameters = new
        {
            Id = id
        };
        return await db.ExecuteAsync("IzbrisiaposlenikaById", parameters, commandType: CommandType.StoredProcedure);
    }
    
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}