/* 
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Pomocnik.Model;

namespace Pomocnik.DAL;

public class DokumentiRepo
{
    private readonly IConfiguration _configuration;

    public DokumentiRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public GetDokumentResponseVM? GetDokumenti(int id)
    {
        using IDbConnection db = GetConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        
        return db.QueryFirstOrDefault<GetDokumentResponseVM>("GetDokumenti", parameters, commandType: CommandType.StoredProcedure);
    }
    
    
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
*/