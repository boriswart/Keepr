using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Keepr.Interfaces;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{

  public class VaultsRepository : IRepo<Vault>
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault Create(Vault data)
    {
      var sql = @"
            INSERT INTO vaults(name, description, isPrivate, creatorId)
            VALUES(@Name, @Description, @isPrivate, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public List<Vault> GetAll()
    {
      string sql = @"
              SELECT
     v.*,
     a.*
     FROM
     vaults v
     JOIN Accounts a ON v.creatorId = a.id
     ";
      // The join requires a Query wheras 
      // [{c:Contract, p: profile}].map(({c,p}) => c.creator = p) // mapping using virtual creator of type Profile
      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }, splitOn: "id").ToList();    // needed above complex return to satisfy Dapper confusion
    }

    internal Vault getOne(int id)
    {
      string sql = "SELECT * FROM vaults v WHERE v.id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    public Vault GetById(int id)
    {
      string sql = @"
              SELECT 
                  k.*,
                  a.*
              FROM keeps k
              JOIN Accounts a ON k.creatorId = a.id
              WHERE k.id = @id;
          ";
      //List<Keep> getData = GetAll();
      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
        {
          v.Creator = p;
          return v;
        }, new { id }, splitOn: "Id").FirstOrDefault();
    }
    public Vault Update(Vault data)
    {
      var sql = @"
                UPDATE vaults
                    SET
                    name = @Name,
                    description = @Description
                    isPrivate = @isPrivate,
                WHERE id = @Id;
                SELECT LAST_INSERT_ID();
            ";
      int rowsAffected = _db.ExecuteScalar<int>(sql, data);
      return data;
    }

  }
}
