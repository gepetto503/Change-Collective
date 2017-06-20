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

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
     //Arrange
    User testUser = new User("ShakyTown", "Marley88", "Jordan", "jdmysliwiec@gmail.com", "I like to Help");

     //Act
     testUser.Save();
     List<User> result = User.GetAll();
     List<User> testList = new List<User>{testUser};

     //Assert
     Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindUserInDatabase()
    {
      //Arrange
      User testUser = new User("ShakyTown", "Marley88", "Jordan", "jdmysliwiec@gmail.com", "I like to Help");
      testUser.Save();

      //Act
      User foundUser = User.Find(testUser.GetId());

      //Assert
      Assert.Equal(testUser, foundUser);
    }

    public void Dispose()
    {
      User.DeleteAll();
      Organization.DeleteAll();
    }
  }
}
