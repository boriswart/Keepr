using System;

namespace Keepr.Models
{

  public class KeepVault
  {

    public int Id { get; set; }
    public string VaultId { get; set; }
    public int KeepId { get; set; }
    // virtual
    public Profile Creator { get; set; }

  }

}
