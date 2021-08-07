using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Keepr.Services;
using Keepr.Models;
using System.Collections.Generic;
using System.Linq;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {

    private readonly VaultsService _vs;

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    public ActionResult<List<Vault>> Get()
    {
      try
      {
        List<Vault> vaults = _vs.GetVaults();
        return Ok(vaults);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> GetOne(int id)
    {
      try
      {
        Vault Vault = _vs.GetVaultById(id);
        return Ok(Vault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Vault> create([FromBody] Vault kData)
    {
      try
      {
        return Ok(_vs.CreateVault(kData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Vault> update([FromBody] Vault vData)
    {
      try
      {
        return Ok(_vs.UpdateVault(vData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    // [HttpGet("{id}/vaults")]
    // public ActionResult<List<VaultKeep>> GetKeepVaults(int id)
    // {
    //   try
    //   {
    //     List<VaultKeep> vaults = _vs.GetVaultKeeps(id);
    //     return Ok(vaults);
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }


  }

}