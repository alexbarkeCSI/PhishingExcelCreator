using Xunit;
using Lib.ReadVictimList;
using Lib.Models;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using System;

namespace PhishingExcelCreator.Tests
{
  public class ReadJsonTests
  {
    [Fact]
    public void ReadJson_WithCorrectInputs_ReturnsCorrectListOfEmployees()
    {

      List<Victim> sampleVictimData = new List<Victim>();
      sampleVictimData.Add(new Victim("Alex Barke", "alex.barke@csintelligence.asia", "R&D"));
      sampleVictimData.Add(new Victim("John Doe", "john.joe@csintelligence.asia", "Sales"));

      using (AutoMock mock = AutoMock.GetLoose())
      {
        mock.Mock<Lib.ReadVictimList.IVictimInfoProvider>()
        .Setup(x => x.GetVictimJson())
        .Returns(sampleVictimData);

        ReadJson sut = mock.Create<ReadJson>();
        List<Victim> actual = sut.GetVictims();
        Assert.NotEmpty(actual);
        Assert.Equal(sampleVictimData.Count, actual.Count);

        for (int i = 0; i < actual.Count; i++)
        {
          Assert.Equal(actual[i].Name, sampleVictimData[i].Name);
          Assert.Equal(actual[i].Email, sampleVictimData[i].Email);
          Assert.Equal(actual[i].Dept, sampleVictimData[i].Dept);
        }
      }
    }
  }
}