using System.Collections.Generic;
using Lib.Models;
using System.Text.Json;

namespace Lib.ReadVictimList
{
  public class VictimInfoProvider : IVictimInfoProvider
  {
    public List<Victim> GetVictimJson()
    {
      const string path = "D:\\PhishingExcelCreator\\PhishingExcelCreator\\ConsoleApp\\bin\\Debug\\netcoreapp3.1\\data2.json";
      string text = System.IO.File.ReadAllText(path);
      List<Victim> victims = JsonSerializer.Deserialize<List<Victim>>(text);
      return victims;
    }
  }
}