using RandomNameGeneratorLibrary;

namespace Lib.GeneratePersons
{
  public class PersonGenerator : IPersonGenerator
  {
    public Person GenerateFemalePerson()
    {
      RandomNameGeneratorLibrary.PersonNameGenerator personNameGenerator = new PersonNameGenerator();
      string firstName = personNameGenerator.GenerateRandomFemaleFirstName();
      string lastName = personNameGenerator.GenerateRandomLastName();

      return new Person(firstName, lastName);
    }

    public Person GenerateMalePerson()
    {
      RandomNameGeneratorLibrary.PersonNameGenerator personNameGenerator = new PersonNameGenerator();
      string firstName = personNameGenerator.GenerateRandomMaleFirstName();
      string lastName = personNameGenerator.GenerateRandomLastName();

      return new Person(firstName, lastName);
    }
  }
}