using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupProject
{
  [Collection("GroupProject")]
  public class CategoryTest : IDisposable
  {
    public CategoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=non_profit_app_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CategoryDbEmpty()
    {
      //Arrange, Act
      int result = Category.GetAll().Count;

      //Assert
      Assert.Equal(result, 0);
    }


    public void Dispose()
    {
      User.DeleteAll();
      Organization.DeleteAll();
      Category.DeleteAll();
    }
  }
}
