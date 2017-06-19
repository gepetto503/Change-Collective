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
      Organization organization1 = new Organization("SaveTheSquirrels", "SaveTheDolphins", "RunningOutOfThingsToSave", "SaveSomethingElse");
      Organization organization2 = new Organization("SaveTheSquirrels", "SaveTheDolphins", "RunningOutOfThingsToSave", "SaveSomethingElse");
      //Assert
      Assert.Equal(organization1, organization2);
    }

    [Fact]
    public void Test_Save_SaveOrganizationToDB()
    {
      //Arrange
      Organization testOrganization = new Organization("SaveTheDolphins", "RunningOutOfThingsToSave", "SaveSomethingElse", "Saving the Planet from Plant People.");
      testOrganization.Save();
      //Act
      List<Organization> result = Organization.GetAll();
      List<Organization> testList = new List<Organization>{testOrganization};
      //Assert
      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Organization.DeleteAll();
      User.DeleteAll();
    }

  }
}
