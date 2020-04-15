using System;
using Lib.ReadVictimList;
using Lib.GenerateVictimList;
using System.Collections.Generic;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ReadJson readJson = new ReadJson(new VictimInfoProvider());
      List<Lib.Models.Victim> victims = readJson.GetVictims();

      GenerateVictims generateVictims = new GenerateVictims();

      DateTime startAtDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(1).Day, 12, 0, 0);
      GenerateOptions options = new GenerateOptions(true, 5,
            startAtDateTime);

      List<Lib.Models.GeneratedVictim> generatedVictims = generateVictims.GenerateVictimList(victims, options);

      foreach (Lib.Models.GeneratedVictim generatedVictim in generatedVictims)
      {
        Console.WriteLine($"{generatedVictim.Name} {generatedVictim.Email} {generatedVictim.Dept} {generatedVictim.SendOutTime}");
      }
    }
  }
}
