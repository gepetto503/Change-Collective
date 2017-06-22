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
<<<<<<< HEAD
      Organization organization1 = new Organization("SaveTheSquirrels", "www.savethesquirrels.org", "savethesquirrels@gmail.com", "Saving the Planet from evil dolphins", "Large bio");
      Organization organization2 = new Organization("SaveTheSquirrels", "www.savethesquirrels.org", "savethesquirrels@gmail.com", "Saving the Planet from evil dolphins", "Large bio");
=======
      Organization organization1 = new Organization("SaveTheSquirrels", "www.savethesquirrels.org", "savethesquirrels@gmail.com", "Saving the Planet from evil dolphins", "Large Bio info");
      Organization organization2 = new Organization("SaveTheSquirrels", "www.savethesquirrels.org", "savethesquirrels@gmail.com", "Saving the Planet from evil dolphins", "Large Bio info");
>>>>>>> 2833c32376329253e063591744a7d5d4d00ea2b3
      //Assert
      Assert.Equal(organization1, organization2);
    }

    [Fact]
    public void Test_Save_SaveOrganizationToDB()
    {
      //Arrange
<<<<<<< HEAD
      Organization testOrganization = new Organization("SaveTheDolphins", "www.savethedophins.org", "savethedolpins@gmail.com", "Saving the Planet from squirrel people.", "Large bio info");
=======
      Organization testOrganization = new Organization("SaveTheDolphins", "www.savethedophins.org", "savethedolpins@gmail.com", "Saving the Planet from squirrel people.", "Large Bio info");
>>>>>>> 2833c32376329253e063591744a7d5d4d00ea2b3
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
<<<<<<< HEAD
      Organization testOrganization = new Organization("SaveTheDolphins","www.savethedophins.org", "savethedolpins@gmail.com", "Saving the Planet from squirrel people.", "Large bio info");
=======
      Organization testOrganization = new Organization("SaveTheDolphins","www.savethedophins.org", "savethedolpins@gmail.com", "Saving the Planet from squirrel people.", "Large Bio info");
>>>>>>> 2833c32376329253e063591744a7d5d4d00ea2b3
      testOrganization.Save();
      //Act
      Organization foundOrganization = Organization.Find(testOrganization.GetId());
      //Assert
      Assert.Equal(testOrganization, foundOrganization);
    }

    [Fact]
    public void Test_UpdateOrganizationNameInDB()
    {
      //Arrange
<<<<<<< HEAD
      Organization testOrganizationName = new Organization("SaveTheMoistOwlet", "wwww.savethemoistowlet.com", "savethemoistowlet@gmail.com", "Save the Planet from evil humans who want to spray owlets with water.", "Large bio info");
=======
      Organization testOrganizationName = new Organization("SaveTheMoistOwlet", "wwww.savethemoistowlet.com", "savethemoistowlet@gmail.com", "Save the Planet from evil humans who want to spray owlets with water.", "Large Bio info");
>>>>>>> 2833c32376329253e063591744a7d5d4d00ea2b3
      testOrganizationName.Save();
      string updateOrganizationName = "SaveTheBirds";
      //Act
      testOrganizationName.Update(updateOrganizationName);
      string resultName = testOrganizationName.GetName();
      //Assert
      Assert.Equal(updateOrganizationName, resultName);
    }

    [Fact]
    public void Test_UpdateOrganizationEmailInDB()
    {
      //Arrange
<<<<<<< HEAD
      Organization testOrganizationEmail = new Organization("SaveTheMoistOwlet", "wwww.savethemoistowlet.com", "savethemoistowlet@gmail.com", "Save the Planet from evil humans who want to spray owlets with water.", "Large bio info");
=======
      Organization testOrganizationEmail = new Organization("SaveTheMoistOwlet", "wwww.savethemoistowlet.com", "savethemoistowlet@gmail.com", "Save the Planet from evil humans who want to spray owlets with water.", "Large Bio info");
>>>>>>> 2833c32376329253e063591744a7d5d4d00ea2b3
      testOrganizationEmail.Save();
      string updateOrganizationEmail = "savethebirds@gmail.com";
      //Act
      testOrganizationEmail.Update(updateOrganizationEmail);
      string resultEmail = testOrganizationEmail.GetEmail();
      //Assert
      Assert.Equal(updateOrganizationEmail, resultEmail);
    }

    [Fact]
    public void Test_UpdateOrganizationBioInDB()
    {
      //Arrange
<<<<<<< HEAD
      Organization testOrganizationBio = new Organization("SaveTheMoistOwlet", "wwww.savethemoistowlet.com", "savethemoistowlet@gmail.com", "Save the Planet from evil humans who want to burn things:(", "Large bio info");
=======
      Organization testOrganizationBio = new Organization("SaveTheMoistOwlet", "wwww.savethemoistowlet.com", "savethemoistowlet@gmail.com", "Save the Planet from evil humans who want to burn things:(", "Large Bio info");
>>>>>>> 2833c32376329253e063591744a7d5d4d00ea2b3
      testOrganizationBio.Save();
      string updateOrganizationBio = "Saving the planet.";
      //Act
      testOrganizationBio.Update(updateOrganizationBio);
      string resultBio = testOrganizationBio.GetBio();
      //Assert
      Assert.Equal(updateOrganizationBio, resultBio);
    }



    public void Dispose()
    {
      Organization.DeleteAll();
      User.DeleteAll();
      Transaction.DeleteAll();
      Category.DeleteAll();
    }

  }
}
