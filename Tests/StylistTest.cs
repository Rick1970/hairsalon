using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

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
      DBConfiguration.ConnectionString = "Data source=(localdb)\\mssqllocaldb; initial Catalog=hair_salon_test;Intergrated Security=SSPI;";
    }
    
  }
  {

  }
}
