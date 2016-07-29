using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SalonList
{
  public class Client
  {
    private int _id;
    private string _name;

    public Client(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
