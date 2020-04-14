using System;

namespace Lib.Models
{
  public class GeneratedVictim
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime SendOutTime { get; set; }
    public string Dept { get; set; }

    public GeneratedVictim(string name, string email, DateTime sendoutTime, string dept)
    {
      Name = name;
      Email = email;
      SendOutTime = sendoutTime;
      Dept = dept;
    }
  }
}