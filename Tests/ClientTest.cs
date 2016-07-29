using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace SalonList
{
  public class ClientTest: IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data source=(localdb)\\mssqllocaldb; initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void T1_ClientEmptyAtFirst()
    {
      //arrange, act
      int result = Client.GetAll().Count;
      //assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void T2_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //arrange, act
      Client firstClient = new Client("Jill");
      Client secondClient = new Client("Jill");
      //Assert
      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void T3_Test_Save_SavesToDatabase()
    {
      //arrange
      Client testList = new Client("Jill");
      //act
      testList.Save();
      List<Client> result = Client.GetAll();
      List<Client> testClient = new List<Client>{testList};
      //Assert
      Assert.Equal(testClient, result);
    }
    [Fact]
    public void T4_Save_AssignsIdToObject()
    {
      //arrange
      Client testClient = new Client("Jill");
      //act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();
      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void T5_Find_FindNameInDatabase()
    {
      //arrange
      Client testClient = new Client("Jill");
      testClient.Save();
      //act
      Client foundClient = Client.Find(testClient.GetId());
      //Assert
      Assert.Equal(testClient, foundClient);
    }

  }
 }
