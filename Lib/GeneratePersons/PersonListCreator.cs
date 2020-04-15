using System.Collections.Generic;
using System.Text.Json;
namespace Lib.GeneratePersons
{
  public class PersonListCreator : IPersonListCreator
  {
    public string GeneratePersonListForExcelCreation(uint num, string domain, string[] depts)
    {
      List<dynamic> persons = new List<dynamic>();
      PersonGenerator personGenerator = new PersonGenerator();
      for (int ndx = 0; ndx < num; ndx++)
      {
        Person p;
        if (ndx % 2 == 0)
        {
          p = personGenerator.GenerateMalePerson();
        }
        else
        {
          p = personGenerator.GenerateFemalePerson();
        }
        string dept = GetDept(depts, ndx);
        var person = new { Name = $"{p.FirstName} {p.LastName}", Email = $"{p.FirstName.ToLower()}.{p.LastName.ToLower()}@{domain}", Dept = dept };
        persons.Add(person);
      }
      return JsonSerializer.Serialize(persons);
    }

    private string GetDept(string[] depts, int index)
    {
      switch (index % 3)
      {
        case 0: return depts[0];
        case 1: return depts[1];
        case 2: return depts[2];
        default:
          return depts[0];
      }
    }

    public string GeneratePersonListJson(uint num)
    {
      List<Person> persons = new List<Person>();
      PersonGenerator personGenerator = new PersonGenerator();
      for (int ndx = 0; ndx < num; ndx++)
      {
        Person p;
        if (ndx % 2 == 0)
        {
          p = personGenerator.GenerateMalePerson();
        }
        else
        {
          p = personGenerator.GenerateFemalePerson();
        }
        persons.Add(p);
      }
      return JsonSerializer.Serialize(persons);
    }
  }
}