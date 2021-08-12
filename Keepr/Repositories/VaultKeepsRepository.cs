using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Interfaces;
using Keepr.Models;

namespace Keepr.Repositories
{

  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public void Create(string accountId, int vaultId, int keepId)
    {
      string sql = @"
            INSERT INTO 
                vault_keeps(accountId, vaultId, keepId)
            VALUES(@accountId, @vaultId, @keepId);
            ";
      _db.ExecuteScalar<int>(sql, new { accountId, vaultId, keepId });
    }

    public List<Keep> GetKeepsByVaultId(int id)
    {
      // REVIEW joining data and mapping to two classes
      string sql = @"
        SELECT
        *
        FROM
        vault_keeps vk
        JOIN keeps k ON k.id = vk.keepId
        WHERE
        vk.Id = @id;
        ";
      //                   vk       k     return type of the entire Query
      return _db.Query<VaultKeep, Keep, Keep>(sql, (vk, k) =>
      {
        return k;
      }, new { id }).ToList();
    }
  }
  // REVIEW needs to return list <Keep> intead of List <VaultKeep>
  // do not know how.....

}