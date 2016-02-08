using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for SqlUtility
/// </summary>
public class SqlUtility
{
    string connectionString;
    SqlCommand cmd;
    SqlConnection connection;


    public SqlUtility()
    {
        connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
        connection = new SqlConnection(connectionString);
        connection.Open();
        cmd = new SqlCommand();
        cmd.Connection = connection;
    }


    public bool IsNotUnique(string username)
    {
        cmd.CommandText = "SELECT COUNT (*) FROM users WHERE username='" + username + "' ";
        int count = (int)cmd.ExecuteScalar();
        connection.Close();
        return (count > 0);
    }


    public string IDForNewUser()
    {
        cmd.CommandText = "SELECT MAX (id) FROM users";
        int id = (int)cmd.ExecuteScalar() + 1;
        connection.Close();
        return id.ToString();
    }

    public string UserCount()
    {
        cmd.CommandText = "SELECT COUNT (*) FROM users";
        int count = (int)cmd.ExecuteScalar();
        connection.Close();
        return count.ToString();
    }


    public bool CreateUser(string username, string fname, string lname, string password, string gender, string email)
    {
        if (this.IsNotUnique(username))
        {
            return false;
        }//if
        else
        {
            connection.Open();
            string id = this.IDForNewUser();
            connection.Open();
            cmd.CommandText = "INSERT INTO users (username, fname, lname, password, id, gender, email,admin) VALUES ('" + username + "', '" + fname + "', '" + lname + "', '" + password + "', '" + id + "', '" + gender + "', '" + email + "', '" + false + "')";

            cmd.ExecuteScalar();
            connection.Close();
            return true;
        }//else
    }
}