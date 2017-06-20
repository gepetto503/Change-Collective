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

    [Fact]
    public void Test_Override_ObjectsAreEqual()
    {
      //Arrange, Act
      Transaction transaction1 = new Transaction("Bank of America", 1000);
      Transaction transaction2 = new Transaction("Bank of America",  1000);
      //Assert
      Assert.Equal(transaction1, transaction2);
    }

    [Fact]
    public void Test_Save_SaveTransactionToDB()
    {
      //Arrange
      Transaction testTransaction = new Transaction("Bank of America", 1023);
      testTransaction.Save();
      //Act
      List<Transaction> result = Transaction.GetAll();
      List<Transaction> testList = new List<Transaction>{testTransaction};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindBankInfoInDB()
    {
      Transaction testTransaction = new Transaction("Bank of America", 100032);
      testTransaction.Save();
      //Act
      Transaction foundTransaction = Transaction.Find(testTransaction.GetId());
      //Assert
      Assert.Equal(testTransaction, foundTransaction);
    }
    
    public void Dispose()
    {
      Transaction.DeleteAll();
      Organization.DeleteAll();
      User.DeleteAll();
    }


  }
}
