using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vRepo;
    private readonly KeepsVaultRepository _kvRepo;

    public VaultsService(VaultsRepository VaultsRepo, KeepsVaultRepository KeepsVaultRepo)
    {
      _vRepo = VaultsRepo;
      _kvRepo = KeepsVaultRepo;
    }


    internal Vault CreateVault(Vault VaultData)
    {
      Vault vault = _vRepo.Create(VaultData);
      return vault;
    }

    internal Vault UpdateVault(Vault VaultData)
    {

      Vault vault = _vRepo.Update(VaultData);
      return vault;
    }



    internal List<Vault> GetVaults()
    {
      return _vRepo.GetAll();
    }

    internal Vault GetVaultById(int id)
    {
      return _vRepo.GetById(id);
    }

    internal List<KeepVault> GetKeepVault(int id)
    {
      throw new NotImplementedException();
    }
  }
}