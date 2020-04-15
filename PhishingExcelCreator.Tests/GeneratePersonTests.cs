using Xunit;
using Lib.GeneratePersons;

namespace PhishingExcelCreator.Tests
{
  public class GeneratePersonTests
  {
    [Fact]
    public void GeneratePerson_CreatesMalePersonCorrectly()
    {
      PersonGenerator personGenerator = new PersonGenerator();
      Person p = personGenerator.GenerateMalePerson();

      Assert.NotEqual("", p.FirstName);
      Assert.NotEqual("", p.LastName);
    }

    [Fact]
    public void GeneratePerson_CreatesFemalePersonCorrectly()
    {
      PersonGenerator personGenerator = new PersonGenerator();
      Person p = personGenerator.GenerateFemalePerson();

      Assert.NotEqual("", p.FirstName);
      Assert.NotEqual("", p.LastName);
    }

    [Fact]
    public void GeneratePersonListJson_CreatesJsonListCorrectly()
    {

      PersonListCreator personListCreator = new PersonListCreator();
      string json = personListCreator.GeneratePersonListJson(5);

      Assert.NotEqual("", json);
    }
  }
}