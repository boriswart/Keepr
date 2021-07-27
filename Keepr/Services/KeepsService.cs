using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

  public class KeepsService
  {
    private readonly KeepsRepository _kRepo;
    private readonly KeepsVaultRepository _kvRepo;


    public KeepsService KeepsRepository KeepsRepo, KeepsVaultRepository KeepsVaultRepo)
    {
      _kRepo = KeepsRepo;
      _kvRepo = KeepsVaultRepo;
    }


  internal Keep CreateKeep(Keep KeepData)
  {
    Keep Keep = _kRepo.Create(KeepData);
    _kRepo.Create(KeepData);
    return Keep;
  }


  internal List<Keep> GetKeeps()
  {
    return _kRepo.GetAll();
  }

  internal Keep GetKeepById(int id)
  {
    return _kRepo.GetById(id);
  }

  internal List<KeepVault> GetKeepsVault(int id)
  {
    List<KeepVault> bids = _kvRepo.GetBidsByKeepId(id);
    return bids;
  }
}
}