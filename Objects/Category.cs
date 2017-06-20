using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace GroupProject
{
  public class Category
  {
    private int _id;
    private string _type;

    public Category(string Type, int Id=0)
    {
      _type = Type;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetType()
    {
      return _type;
    }
    public void SetType(string newType)
    {
      _type = newType;
    }

    public static List<Category> GetAll()
    {
      List<Category> allCategories = new List<Category> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM categories;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int categoryId = rdr.GetInt32(0);
        string type = rdr.GetString(1);
        Category newCategory = new Category(type, categoryId);
        allCategories.Add(newCategory);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allCategories;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM categories;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    public override int GetHashCode()
    {
      return this.GetType().GetHashCode();
    }
    public override bool Equals(System.Object otherCategory)
    {
      if(!(otherCategory is Category))
      {
        return false;
      }
      else
      {
        Category newCategory = (Category) otherCategory;
        bool idEquality = this.GetId() == newCategory.GetId();
        bool typeEquality = this.GetType() == newCategory.GetType();
        return (idEquality && typeEquality);
      }
    }
  }
}
