using System;

namespace Lib.GenerateVictimList
{
  public class GenerateOptions
  {
    public bool Randomize { get; set; }
    public uint MinutesBetweenScheduledEmails { get; set; }
    public DateTime StartAtDateTime { get; set; }

    public GenerateOptions()
    {
    }

    public GenerateOptions(bool randomize, uint minutesBetweenScheduledEmails, DateTime startAtDateTime)
    {
      Randomize = randomize;
      MinutesBetweenScheduledEmails = minutesBetweenScheduledEmails;
      StartAtDateTime = startAtDateTime;
    }
  }
}