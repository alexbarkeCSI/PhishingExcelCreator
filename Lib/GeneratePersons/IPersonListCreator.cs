namespace Lib.GeneratePersons
{
  public interface IPersonListCreator
  {
    string GeneratePersonListJson(uint num);
    string GeneratePersonListForExcelCreation(uint num, string domain, string[] depts);
  }
}