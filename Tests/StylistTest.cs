using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace SalonList
{
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data source=(localdb)\\mssqllocaldb; initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void T1_StylistEmptyAtFirst()
    {
      //arrange, act
      int result = Stylist.GetAll().Count;
      //assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void T2_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //arrange, act
      Stylist firstStylist = new Stylist("Jane");
      Stylist secondStylist = new Stylist("Jane");
      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void T3_Test_Save_SavesToDatabase()
    {
      //arrange
      Stylist testStylist = new Stylist("Jane");
      //act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};
      //Assert
      Assert.Equal(testList, result);
    }
   }
  }
