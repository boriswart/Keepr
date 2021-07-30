using System;
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
  public class KeepsController : ControllerBase
  {

    private readonly KeepsService _ks;

    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet]
    public ActionResult<List<Keep>> Get()
    {
      try
      {
        List<Keep> keeps = _ks.GetKeeps().ToList();
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetOne(int id)
    {
      try
      {
        Keep keep = _ks.GetKeepById(id);
        return Ok(keep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Keep> create([FromBody] Keep kData)
    {
      try
      {
        return Ok(_ks.CreateKeep(kData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Keep> update(int id, [FromBody] Keep kData)
    {
      try
      {
        return Ok(_ks.UpdateKeep(kData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    [HttpGet("{id}/vaults")]
    public ActionResult<List<KeepVault>> GetKeepVaults(int id)
    {
      try
      {
        List<KeepVault> vaults = _ks.GetKeepVault(id);
        return Ok(vaults);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }

}