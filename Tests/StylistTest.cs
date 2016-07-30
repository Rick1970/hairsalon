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
      Client.DeleteAll();
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
    [Fact]
    public void T4_Save_AssignsIdToObject()
    {
      //arrange
      Stylist testStylist = new Stylist("Jane");
      //act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();
      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void T5_Find_FindNameInDatabase()
    {
      //arrange
      Stylist testStylist = new Stylist("Jane");
      testStylist.Save();
      //act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());
      //Assert
      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void T6_GetClients_RetrievesAllClientsWithStylist()
    {
      Stylist testStylist = new Stylist("Jane");
      testStylist.Save();

      Client firstClient = new Client("Jill", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("Lisa", testStylist.GetId());
      secondClient.Save();


      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }
    [Fact]
    public void T7_Update_UpdatesStylistInDatabase()
    {
      //Arrange
      string name = "Mike";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "Lucy";
      //Act
      testStylist.Update(newName);
      string result = testStylist.GetName();
      //Assert
      Assert.Equal(newName, result);
    }
  }
}
