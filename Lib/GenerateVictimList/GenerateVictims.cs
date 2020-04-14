using System.Collections.Generic;
using Lib.Models;
using System;
using System.Linq;
using Lib.ListExtensions;

namespace Lib.GenerateVictimList
{
  public class GenerateVictims
  {
    public List<GeneratedVictim> GenerateVictimList(List<Victim> victimInputs, GenerateOptions options)
    {
      if (victimInputs.Count == 0) return new List<GeneratedVictim>();

      if (options.Randomize == false) return GroupByDept(victimInputs, options);
      return RandomizeVictims(victimInputs, options);
    }

    private List<GeneratedVictim> RandomizeVictims(List<Victim> victimInputs, GenerateOptions options)
    {
      DateTime sendOutTime = options.StartAtDateTime;

      List<GeneratedVictim> output = new List<GeneratedVictim>();

      // shuffle order of victims
      victimInputs.Shuffle();

      foreach (Victim victim in victimInputs)
      {
        GeneratedVictim generatedVictim = new GeneratedVictim(victim.Name, victim.Email, sendOutTime, victim.Dept);

        sendOutTime = sendOutTime.AddMinutes(options.MinutesBetweenScheduledEmails);

        output.Add(generatedVictim);
      }

      return output;
    }

    private List<GeneratedVictim> GroupByDept(List<Victim> victimInputs, GenerateOptions options)
    {
      List<Victim> sortedVictims = victimInputs.OrderBy(p => p.Dept).ThenBy(q => q.Name).ToList();
      DateTime sendOutTime = options.StartAtDateTime;

      List<GeneratedVictim> output = new List<GeneratedVictim>();

      foreach (Victim victim in sortedVictims)
      {
        GeneratedVictim generatedVictim = new GeneratedVictim(victim.Name, victim.Email, sendOutTime, victim.Dept);

        sendOutTime = sendOutTime.AddMinutes(options.MinutesBetweenScheduledEmails);

        output.Add(generatedVictim);
      }

      return output;
    }
  }
}