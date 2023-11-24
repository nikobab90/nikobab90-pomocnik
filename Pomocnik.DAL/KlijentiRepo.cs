using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Pomocnik.Model;

namespace Pomocnik.DAL;

public class KlijentiRepo
{
    private readonly IConfiguration _configuration;

    public KlijentiRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public GetKlijentResponseVM? GetTvrtka(int id)
    {
        using IDbConnection db = GetConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        
        return db.QueryFirstOrDefault<GetKlijentResponseVM>("GetTvrtka", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<List<GetAllKlijentiResponseVM>> GetAllTvrtka()
    {
        using IDbConnection db = GetConnection();

        IEnumerable<GetAllKlijentiResponseVM> klijenti = await db.QueryAsync<GetAllKlijentiResponseVM>(
            "GetAllTvrtka", commandType: CommandType.StoredProcedure);

        return klijenti.ToList();
    }
    
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}