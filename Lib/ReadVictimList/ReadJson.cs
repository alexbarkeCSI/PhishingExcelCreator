using System.Collections.Generic;
using Lib.Models;

namespace Lib.ReadVictimList
{
  public class ReadJson
  {
    private readonly IVictimInfoProvider _provider;
    public ReadJson(IVictimInfoProvider provider)
    {
      _provider = provider;
    }

    public List<Victim> GetVictims()
    {
      return _provider.GetVictimJson();
    }
  }
}