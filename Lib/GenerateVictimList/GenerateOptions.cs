using System;

namespace Lib.GenerateVictimList
{
  public class GenerateOptions
  {
    public bool Randomize { get; set; }
    public uint MinutesBetweenScheduledEmails { get; set; }
    public DateTime StartAtDateTime { get; set; }
    public uint MinimumHour { get; set; }
    public uint MinimumMinute { get; set; }
    public uint MaximumHour { get; set; }
    public uint MaximumMinute { get; set; }

    public GenerateOptions()
    {
    }

    public GenerateOptions(bool randomize, uint minutesBetweenScheduledEmails, DateTime startAtDateTime, uint minimumHour, uint minimumMinute, uint maximumHour, uint maximumMinute)
    {
      Randomize = randomize;
      MinutesBetweenScheduledEmails = minutesBetweenScheduledEmails;
      StartAtDateTime = startAtDateTime;
      MinimumHour = minimumHour;
      MinimumMinute = minimumMinute;
      MaximumHour = maximumHour;
      MaximumMinute = maximumMinute;

    }
  }
}