using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Keepr.Interfaces;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository : IRepo<Keep>
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Keep Create(Keep data)
    {
      var sql = @"
            INSERT INTO keeps(name, description, location, creatorId)
            VALUES(@Name, @Description, @Location, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public List<Keep> GetAll()
    {
      string sql = @"
              SELECT
     k.*,
     a.*
     FROM
     keeps k
     JOIN Accounts a ON k.creatorId = a.id
     ";

      // The join requires a Query wheras 
      // [{c:Contract, p: profile}].map(({c,p}) => c.creator = p) // mapping using virtual creator of type Profile
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, splitOn: "id").ToList();    // needed above complex return to satisfy Dapper confusion
    }

    internal Keep getOne(int id)
    {
      string sql = "SELECT * FROM keeps k WHERE k.id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    public Keep GetById(int id)
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
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
        {
          k.Creator = p;
          return k;
        }, new { id }, splitOn: "Id").FirstOrDefault();
    }

    public Keep Update(Keep data)
    {
      var sql = @"
                UPDATE keeps
                    SET
                    name = @Name,
                    img = @Img,
                    description = @Description
                WHERE id = @Id;
            ";
      var rowsAffected = _db.Execute(sql, data);
      if (rowsAffected > 1)
      {
        throw new Exception("Ahhhhh that was probably really bad");
      }
      if (rowsAffected < 1)
      {
        throw new Exception("woops update didn't work no idea why probably a bad id");
      }
      return data;
    }
  }
}