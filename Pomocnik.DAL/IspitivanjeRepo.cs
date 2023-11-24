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
    // Http zahtjev: dohvati ispitivanje po id-u
    public GetIspitivanjeResponseVM? GetIspitivanje(int id)
    {
        using IDbConnection db = GetConnection();
        
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

        return db.QueryFirstOrDefault<GetIspitivanjeResponseVM>("GetIspitivanje", parameters, commandType: CommandType.StoredProcedure);
    }
    // dodaj novo ispitivanje
    public void PostIspitivanje(PostIspitivanjeVM ispitivanje)
    {
        using IDbConnection db = GetConnection();
        
            var parameters = new DynamicParameters();
            parameters.Add("@SerijskiBroj", ispitivanje.SerijskiBroj, DbType.String, ParameterDirection.Input);
            parameters.Add("@TvornickiBroj", ispitivanje.TvornickiBroj, DbType.String, ParameterDirection.Input);
            parameters.Add("@DatumOd", ispitivanje.DatumOd, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@DatumDo", ispitivanje.DatumDo, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Cijena", ispitivanje.Cijena, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Pdv", ispitivanje.Pdv, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@TvrtkaId", ispitivanje.TvrtkaId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@VrstaIspitivanjaId", ispitivanje.VrstaIspitivanjaId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@LokacijaId", ispitivanje.LokacijaId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ZaposlenikId", ispitivanje.ZaposlenikId, DbType.Int32, ParameterDirection.Input);

            db.Execute("PostIspitivanje", parameters, commandType: CommandType.StoredProcedure);
    }
    
    // dohvati sva ispitivanja
    public List<GetAllIspitivanjeResponseVM?> GetAllIspitivanje()
    {
        using IDbConnection db = GetConnection();
    
        var ispitivanja = db.Query<GetAllIspitivanjeResponseVM>("GetAllIspitivanje", commandType: CommandType.StoredProcedure).ToList();

        return ispitivanja;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}