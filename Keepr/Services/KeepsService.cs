using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

  public class KeepsService
  {
    private readonly KeepsRepository _kRepo;
    private readonly VaultKeepsRepository _vkRepo;


    public KeepsService(KeepsRepository KeepsRepo, VaultKeepsRepository VaultKeepsRepo)
    {
      _kRepo = KeepsRepo;
      _vkRepo = VaultKeepsRepo;
    }


    internal Keep CreateKeep(Keep KeepData)
    {
      Keep keep = _kRepo.Create(KeepData);
      return keep;
    }

    internal Keep UpdateKeep(Keep KeepData)
    {

      Keep keep = _kRepo.Update(KeepData);
      return keep;
    }

    internal List<Keep> GetKeeps()
    {
      return _kRepo.GetAll();
    }

    internal Keep GetKeepById(int id)
    {
      return _kRepo.GetById(id);
    }

    internal List<VaultKeep> GetVaultKeeps(int id)
    {
      throw new NotImplementedException("Yo Mama no implementation");
    }
  }
}