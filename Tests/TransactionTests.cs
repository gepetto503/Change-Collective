using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupProject
{
  [Collection("GroupProject")]
  public class TransactionTests : IDisposable
  {
    public TransactionTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=non_profit_app_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_TransactionEmptyAtFirst()
    {
      //Arrange, Act
      int result =  Transaction.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    public void Dispose()
    {
      Transaction.DeleteAll();
      Organization.DeleteAll();
      User.DeleteAll();
    }


  }
}
