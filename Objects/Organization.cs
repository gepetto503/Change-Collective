using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace GroupProject
{
  public class Organization
  {
    private int _id;
    private string _name, _website, _email, _bio, _largeBio;

    public Organization(string Name, string Website, string Email, string Bio, string LargeBio, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _website = Website;
      _email = Email;
      _bio = Bio;
      _largeBio = LargeBio;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetWebsite()
    {
      return _website;
    }
    public string GetEmail()
    {
      return _email;
    }
    public string GetBio()
    {
      return _bio;
    }
    public string GetLargeBio()
    {
      return _largeBio;
    }

    public override bool Equals(System.Object otherOrganization)
    {
      if(!(otherOrganization is Organization))
      {
        return false;
      }
      else
      {
        Organization newOrganization = (Organization) otherOrganization;
        bool idEquality = (this.GetId() == newOrganization.GetId());
        bool nameEquality = (this.GetName() == newOrganization.GetName());
        bool websiteEquality = (this.GetWebsite() == newOrganization.GetWebsite());
        bool emailEquality = (this.GetEmail() == newOrganization.GetEmail());
        bool bioEquality = (this.GetBio() == newOrganization.GetBio());
        bool largeBioEquality = (this.GetLargeBio() == newOrganization.GetLargeBio());
        return (idEquality && nameEquality && websiteEquality && emailEquality && bioEquality && largeBioEquality);
      }
    }

      public override int GetHashCode()
      {
        return this.GetName().GetHashCode();
      }

    public static List<Organization> GetAll()
    {
      List<Organization> AllOrganizations = new List<Organization>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM organizations;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string website = rdr.GetString(2);
        string email = rdr.GetString(3);
        string bio = rdr.GetString(4);
        string largeBio = rdr.GetString(5);
        Organization newOrganization = new Organization(name, website, email, bio, largeBio, id);
        AllOrganizations.Add(newOrganization);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return AllOrganizations;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO organizations (name, website, email, bio, large_bio) OUTPUT INSERTED.id VALUES (@Name, @Website, @Email, @Bio, @largeBio);", conn);
      SqlParameter nameParam = new SqlParameter("@Name", this.GetName());
      SqlParameter websiteParam = new SqlParameter("@Website", this.GetWebsite());
      SqlParameter emailParam = new SqlParameter("@Email", this.GetEmail());
      SqlParameter bioParam = new SqlParameter("@Bio", this.GetBio());
      SqlParameter largeBioParam = new SqlParameter("@largeBio", this.GetLargeBio());

      cmd.Parameters.Add(nameParam);
      cmd.Parameters.Add(websiteParam);
      cmd.Parameters.Add(emailParam);
      cmd.Parameters.Add(bioParam);
      cmd.Parameters.Add(largeBioParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Organization Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM organizations WHERE id = @Id;", conn);
      SqlParameter IdParam = new SqlParameter("@Id", id.ToString());

      cmd.Parameters.Add(IdParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string name = null;
      string website = null;
      string email = null;
      string bio = null;
      string largeBio = null;

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        website = rdr.GetString(2);
        email = rdr.GetString(3);
        bio = rdr.GetString(4);
        largeBio = rdr.GetString(5);
      }
      Organization foundOrganization = new Organization(name, website, email, bio, largeBio, foundId);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundOrganization;
    }

    public void Update(string updateOrganizationInfo)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE organizations SET name = @Name WHERE id = @Id; UPDATE organizations SET email = @Email WHERE id = @Id; UPDATE organizations SET bio = @Bio WHERE id = @Id; UPDATE organizations SET large_bio =@LargeBio WHERE id = @Id;",  conn);

      SqlParameter nameParm = new SqlParameter("@Name", updateOrganizationInfo);
      SqlParameter emailParam = new SqlParameter("@Email", updateOrganizationInfo);
      SqlParameter bioParam = new SqlParameter("@Bio", updateOrganizationInfo);
      SqlParameter largeBioParam = new SqlParameter("@LargeBio", updateOrganizationInfo);
      SqlParameter idParam = new SqlParameter("@Id", this.GetId());

      cmd.Parameters.Add(nameParm);
      cmd.Parameters.Add(emailParam);
      cmd.Parameters.Add(bioParam);
      cmd.Parameters.Add(largeBioParam);
      cmd.Parameters.Add(idParam);

      this._name = updateOrganizationInfo;
      this._email = updateOrganizationInfo;
      this._bio = updateOrganizationInfo;
      this._largeBio = updateOrganizationInfo;
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM organizations;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
