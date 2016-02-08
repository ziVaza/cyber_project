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

        connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\סייבר\סייבר\server\LogIn.mdf;Integrated Security=True";
        connection = new SqlConnection(connectionString);
        connection.Open();
        cmd = new SqlCommand();
        cmd.Connection = connection;
    }


    public bool IsNotUnique(string username)
    {
        cmd.CommandText = "SELECT COUNT (*) FROM ServerDB WHERE username='" + username + "' ";
        int count = (int)cmd.ExecuteScalar();
        connection.Close();
        return (count > 0);
    }

    //public bool IsExist(string username)
    //{
       
    //    return true;
    //}

    public bool UpdatePass(string username, string newpass)
    {
        cmd.CommandText = "UPDATE ServerDB SET password ='" + newpass + "'WHERE username='" + username + "' ";
        cmd.ExecuteScalar();
        connection.Close();
        return true;
    }

    public bool UserExist(string username, string password)
    {
        cmd.CommandText = "SELECT COUNT (*) FROM ServerDB WHERE username='" + username +"' ";
        int count = (int)cmd.ExecuteScalar();
        if (count > 0)
        {
            cmd.CommandText = "SELECT (password) FROM ServerDB WHERE username='" + username + "' ";
            string passfromtable = (string)cmd.ExecuteScalar();
            if (passfromtable == password)
            {
                connection.Close();
                return true;
            }
        }
        connection.Close();
        return false;
    }

    //public string IDForNewUser()
    //{
    //    cmd.CommandText = "SELECT MAX (id) FROM users";
    //    int id = (int)cmd.ExecuteScalar() + 1;
    //    connection.Close();
    //    return id.ToString();
    //}

    public string UserCount()
    {
        cmd.CommandText = "SELECT COUNT (*) FROM ServerDB";
        int count = (int)cmd.ExecuteScalar();
        connection.Close();
        return count.ToString();
    }


    public bool CreateUser(string username, string password)
    {
        if (this.IsNotUnique(username))
        {
            return false;
        }//if
        else
        {
            connection.Open();
            
            connection.Open();
            cmd.CommandText = "INSERT INTO ServerDB (username, password) VALUES ('" + username + "', '" + password +"')";

            cmd.ExecuteScalar();
            connection.Close();
            return true;
        }//else
    }
}