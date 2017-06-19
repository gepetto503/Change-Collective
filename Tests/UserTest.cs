using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupProject
{
  [Collection("GroupProject")]
  public class UserTest : IDisposable
  {
    public UserTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=non_profit_app_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DBEmpty()
    {
      //arrange, act
      int result = User.GetAll().Count;
      //assert
      Assert.Equal(0, result);
    }


    public void Dispose()
    {
      User.DeleteAll();
    }
  }
}
