using System.Collections.Generic;
using Lib.Models;
using System;
using System.Linq;

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

      Console.WriteLine("Shuffling...");
      List<Victim> shuffled = victimInputs.OrderBy(a => Guid.NewGuid()).ToList();

      foreach (Victim victim in shuffled)
      {
        sendOutTime = GenerateNextSendOutTime(sendOutTime, options);

        GeneratedVictim generatedVictim = new GeneratedVictim(victim.Name, victim.Email, sendOutTime, victim.Dept);

        sendOutTime = sendOutTime.AddMinutes(options.MinutesBetweenScheduledEmails);

        output.Add(generatedVictim);
      }

      return output.OrderBy(p => p.SendOutTime).ToList();
    }

    private List<GeneratedVictim> GroupByDept(List<Victim> victimInputs, GenerateOptions options)
    {
      List<Victim> sortedVictims = victimInputs.OrderBy(p => p.Dept).ThenBy(q => q.Name).ToList();
      DateTime sendOutTime = options.StartAtDateTime;

      List<GeneratedVictim> output = new List<GeneratedVictim>();

      foreach (Victim victim in sortedVictims)
      {
        sendOutTime = GenerateNextSendOutTime(sendOutTime, options);

        GeneratedVictim generatedVictim = new GeneratedVictim(victim.Name, victim.Email, sendOutTime, victim.Dept);

        sendOutTime = sendOutTime.AddMinutes(options.MinutesBetweenScheduledEmails);

        output.Add(generatedVictim);
      }

      return output.OrderBy(p => p.SendOutTime).ToList();
    }

    private static DateTime GenerateNextSendOutTime(DateTime currentSendOutTime, GenerateOptions options)
    {
      DateTime potentialNewTime = currentSendOutTime;//.AddMinutes(options.MinutesBetweenScheduledEmails);

      while (
        potentialNewTime.Hour > options.MaximumHour || // hour is too high 
        potentialNewTime.Hour == options.MaximumHour && potentialNewTime.Minute > options.MaximumMinute || // hour and minute too high
        potentialNewTime.Hour < options.MinimumHour || // hour is too small
        potentialNewTime.Hour == options.MinimumHour && potentialNewTime.Minute < options.MinimumMinute) // hour and minute is too low
      {
        potentialNewTime = potentialNewTime.AddMinutes(options.MinutesBetweenScheduledEmails);
      }

      return potentialNewTime;
    }
  }
}