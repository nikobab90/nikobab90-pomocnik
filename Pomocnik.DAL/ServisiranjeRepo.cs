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
    public List<GetAllServisiranjeResponseVM?> GetAllServisiranje()
    {
        using IDbConnection db = GetConnection();
    
        var servisi = db.Query<GetAllServisiranjeResponseVM>("GetAllServisiranje", commandType: CommandType.StoredProcedure).ToList();

        return servisi;
    }
    
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}