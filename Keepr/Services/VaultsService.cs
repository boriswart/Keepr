using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vRepo;
    private readonly VaultKeepsRepository _vkRepo;

    public VaultsService(VaultsRepository VaultsRepo, VaultKeepsRepository VaultKeepsRepo)
    {
      _vRepo = VaultsRepo;
      _vkRepo = VaultKeepsRepo;
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

    internal List<VaultKeep> GetKeepsByVaultId(int id)
    {
      return _vkRepo.GetKeepsByVaultId(id);
    }
  }
}