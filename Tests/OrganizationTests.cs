using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupProject
{
  [Collection("GroupProject")]
  public class OrganizationTests : IDisposable
  {
    public OrganizationTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=non_profit_app_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_OrganizationEmptyAtFirst()
    {
      //Arrange, Act
      int result = Organization.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Override_ObjectsAreEqual()
    {
      //Arrange, Act
      Organization organization1 = new Organization("SaveTheSquirrels", "www.savethesquirrels.org", "savethesquirrels@gmail.com", "Saving the Planet from evil dolphins");
      Organization organization2 = new Organization("SaveTheSquirrels", "www.savethesquirrels.org", "savethesquirrels@gmail.com", "Saving the Planet from evil dolphins");
      //Assert
      Assert.Equal(organization1, organization2);
    }

    [Fact]
    public void Test_Save_SaveOrganizationToDB()
    {
      //Arrange
      Organization testOrganization = new Organization("SaveTheDolphins", "www.savethedophins.org", "savethedolpins@gmail.com", "Saving the Planet from squirrel people.");
      testOrganization.Save();
      //Act
      List<Organization> result = Organization.GetAll();
      List<Organization> testList = new List<Organization>{testOrganization};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindOrganizationInDb()
    {
      //Arrange
      Organization testOrganization = new Organization("SaveTheDolphins","www.savethedophins.org", "savethedolpins@gmail.com", "Saving the Planet from squirrel people.");
      testOrganization.Save();
      //Act
      Organization foundOrganization = Organization.Find(testOrganization.GetId());
      //Assert
      Assert.Equal(testOrganization, foundOrganization);
    }



    public void Dispose()
    {
      Organization.DeleteAll();
      User.DeleteAll();
    }

  }
}
