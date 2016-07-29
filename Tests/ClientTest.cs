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

  }
 }
