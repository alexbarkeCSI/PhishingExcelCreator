using System;
using Lib.ReadVictimList;
using Lib.GenerateVictimList;
using System.Collections.Generic;
using Lib.GeneratePersons;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Phishing Excel Creator");
      Console.WriteLine("Options:");
      Console.WriteLine("Press 1 to Generate JSON Results");
      Console.WriteLine("Press 2 to Generate Victims");

      string key = Console.ReadLine();
      if (key == "1")
      {
        CreateJsonList();
      }
      else if (key == "2")
      {
        GenerateVictims();
      }
      else
      {
        Console.WriteLine("Unknown input.");
      }
    }

    private static void GenerateVictims()
    {
      ReadJson readJson = new ReadJson(new VictimInfoProvider());
      List<Lib.Models.Victim> victims = readJson.GetVictims();

      GenerateVictims generateVictims = new GenerateVictims();

      DateTime startAtDateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(1).Day, 12, 0, 0);
      GenerateOptions options = new GenerateOptions(
        true,
        5,
        startAtDateTime,
        8,
        30,
        18,
        0);

      List<Lib.Models.GeneratedVictim> generatedVictims = generateVictims.GenerateVictimList(victims, options);

      foreach (Lib.Models.GeneratedVictim generatedVictim in generatedVictims)
      {
        Console.WriteLine($"{generatedVictim.Name},{generatedVictim.Email},{generatedVictim.Dept},{generatedVictim.SendOutTime}");
      }
    }

    private static void CreateJsonList()
    {
      PersonListCreator personListCreator = new PersonListCreator();
      string jsonForExcel = personListCreator.GeneratePersonListForExcelCreation(350, "mentormedia.com", new string[] { "Research and Development", "Sales", "Marketing" });
      Console.WriteLine(jsonForExcel);
    }
  }
}
