using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace GroupProject
{
  public class User
  {
    private int _id;
    private string _userName;
    private string _password;
    private string _name;
    private string _email;
    private string _bio;

    public User(string UserName, string Password, string Name, string Email, string Bio, int Id=0)
    {
      _id = Id;
      _userName = UserName;
      _password = Password;
      _name = Name;
      _email = Email;
      _bio = Bio;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetUserName()
    {
      return _userName;
    }
    public string GetPassword()
    {
      return _password;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetEmail()
    {
      return _email;
    }
    public string GetBio()
    {
      return _bio;
    }


    public void SetUserName(string newUserName)
    {
      _userName = newUserName;
    }
    public void SetPassword(string newPassword)
    {
      _password = newPassword;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void SetEmail(string newEmail)
    {
      _email = newEmail;
    }
    public void SetBio(string newBio)
    {
      _bio = newBio;
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }

    public static List<User> GetAll()
    {
      List<User> allUsers = new List<User> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM users;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        string password = rdr.GetString(2);
        string name = rdr.GetString(3);
        string email = rdr.GetString(4);
        string bio = rdr.GetString(5);
        User newUser = new User(userName, password, name, email, bio, userId);
        allUsers.Add(newUser);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allUsers;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO users (user_name, password, name, email, bio) OUTPUT INSERTED.id VALUES (@UserName, @Password, @Name, @Email, @Bio);", conn);

      SqlParameter userNamePara = new SqlParameter("@UserName", this.GetUserName());
      SqlParameter passwordPara = new SqlParameter("@Password", this.GetPassword());
      SqlParameter namePara = new SqlParameter("@Name", this.GetName());
      SqlParameter emailPara = new SqlParameter("@Email", this.GetEmail());
      SqlParameter bioPara = new SqlParameter("@Bio", this.GetBio());

      cmd.Parameters.Add(userNamePara);
      cmd.Parameters.Add(passwordPara);
      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(emailPara);
      cmd.Parameters.Add(bioPara);


      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static User Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM  users WHERE id = @UserId;", conn);
      SqlParameter userIdParameter = new  SqlParameter("@UserId", id.ToString());
      cmd.Parameters.Add(userIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundUserId = 0;
      string foundUserName = null;
      string foundPassword = null;
      string foundName = null;
      string foundEmail = null;
      string foundBio = null;

      while(rdr.Read())
      {
        foundUserId = rdr.GetInt32(0);
        foundUserName = rdr.GetString(1);
        foundPassword = rdr.GetString(2);
        foundName = rdr.GetString(3);
        foundEmail = rdr.GetString(4);
        foundBio = rdr.GetString(5);
      }
      User foundUser = new  User(foundUserName, foundPassword, foundName, foundEmail, foundBio, foundUserId);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundUser;
    }

    public static User UserLookup(string username)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE user_name = @Username", conn);
      cmd.Parameters.Add(new SqlParameter("@Username", username));

      SqlDataReader rdr = cmd.ExecuteReader();

      int foundUserId = 0;
      string foundUserName = null;
      string foundPassword = null;
      string foundName = null;
      string foundEmail = null;
      string foundBio = null;

      while(rdr.Read())
      {
        foundUserId = rdr.GetInt32(0);
        foundUserName = rdr.GetString(1);
        foundPassword = rdr.GetString(2);
        foundName = rdr.GetString(3);
        foundEmail = rdr.GetString(4);
        foundBio = rdr.GetString(5);
      }
      User foundUser = new  User(foundUserName, foundPassword, foundName, foundEmail, foundBio, foundUserId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return foundUser;
    }


    public void Update(string userInfo)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE users SET name = @NewName OUTPUT INSERTED.name WHERE id = @UserId; UPDATE users SET email = @NewEmail OUTPUT INSERTED.email WHERE id = @UserId; UPDATE users SET bio = @NewBio OUTPUT INSERTED.bio WHERE id = @UserId;", conn);

      SqlParameter newNameParameter = new SqlParameter("@NewName", userInfo);
      SqlParameter newEmailParameter = new SqlParameter("@NewEmail", userInfo);
      SqlParameter newBioParameter = new SqlParameter("@NewBio", userInfo);
      SqlParameter userIdParameter = new SqlParameter("@UserId", this.GetId());

      cmd.Parameters.Add(newNameParameter);
      cmd.Parameters.Add(newEmailParameter);
      cmd.Parameters.Add(newBioParameter);
      cmd.Parameters.Add(userIdParameter);

      this._name = userInfo;
      this._email = userInfo;
      this._bio = userInfo;

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
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

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM users;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public override bool Equals(System.Object otherUser)
    {
      if (!(otherUser is User))
      {
        return false;
      }
      else
      {
        User newUser = (User) otherUser;
        bool idEquality = (this.GetId() == newUser.GetId());
        bool nameEquality = (this.GetName() == newUser.GetName());
        return (idEquality && nameEquality);
      }
    }
  }
}
