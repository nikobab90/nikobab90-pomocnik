using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Pomocnik.Model;

namespace Pomocnik.DAL;

public class ServisiranjeRepo
{
    private readonly IConfiguration _configuration;

    public ServisiranjeRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    //dohvati servisiranje po id-u
    public GetServisiranjeResponseVM? GetServisiranje(int id)
    {
        using IDbConnection db = GetConnection();
        
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        
        return db.QueryFirstOrDefault<GetServisiranjeResponseVM>("GetServisiranje", parameters, commandType: CommandType.StoredProcedure);
    }
    //dohvati sva servisiranja
    public async Task<List<GetAllServisiranjeResponseVM>> GetAllServisiranje()
    {
        using IDbConnection db = GetConnection();
    
        IEnumerable<GetAllServisiranjeResponseVM> servisi = await db.QueryAsync<GetAllServisiranjeResponseVM>
            ("GetAllServisiranje", commandType: CommandType.StoredProcedure);

        return servisi.ToList();
    }
    
    // dodaj novo Servisiranje
    public async Task<int> PostServisiranje(PostServisiranjeVM servisiranje)
    {
        using IDbConnection db = GetConnection();
        var result = await db.QueryAsync<int>("PostServisiranje",
            new
            {
                servisiranje.SerijskiBroj,
                servisiranje.TvornickiBroj,
                servisiranje.DatumOd,
                servisiranje.DatumDo,
                servisiranje.Cijena,
                servisiranje.Pdv,
                servisiranje.TvrtkaId,
                servisiranje.VrstaServisiranjaId,
                servisiranje.LokacijaId,
                servisiranje.ZaposlenikId
            },
            commandType: CommandType.StoredProcedure);
        return result.First();
    }
    
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}