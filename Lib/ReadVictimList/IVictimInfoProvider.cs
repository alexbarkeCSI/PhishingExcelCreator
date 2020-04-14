using System.Collections.Generic;
using Lib.Models;

namespace Lib.ReadVictimList
{
  public interface IVictimInfoProvider
  {
    List<Victim> GetVictimJson();
  }
}