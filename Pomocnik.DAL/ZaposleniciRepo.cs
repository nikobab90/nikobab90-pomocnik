﻿using System.Data;
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
    // dohvati zaposlenika po id-u
    public GetZaposlenikResponseVM? GetZaposlenik(int id)
    {
        using IDbConnection db = GetConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        
        return db.QueryFirstOrDefault<GetZaposlenikResponseVM>("Getzaposlenik", parameters, commandType: CommandType.StoredProcedure);
    }
    
    // dohvati sve zaposlenike
    public List<GetAllZaposleniciResponseVM?> GetAllZaposlenici()
    {
        using IDbConnection db = GetConnection();
        
        var zaposlenici = db.Query<GetAllZaposleniciResponseVM>("GetAllZaposlenici", commandType: CommandType.StoredProcedure).ToList();

        return zaposlenici;
    }
    
    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}