using System;
namespace Lib.Models
{
  public class Victim
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Dept { get; set; }
    public Victim()
    {

    }
    public Victim(string name, string email, string dept)
    {
      Name = name;
      Email = email;
      Dept = dept;
    }
  }
}