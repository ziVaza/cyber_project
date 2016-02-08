using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ShowUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["table"] = Request.Form["table"];

        if ((string)Session["table"]=="All users")
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM users";

        SqlDataReader rdr = cmd.ExecuteReader();
        string allUsersString = "";
        allUsersString += "<div class='container'>";
        allUsersString += "<h1>All Users</h1>";
        allUsersString += "<table class='table table-hover'>";
        allUsersString += "<tr><th>Id</th><th>Username</th><th>Email</th><th>First Name</th><th>Last Name</th><th>Gender</th><th>Type of User</th></tr>";
        while (rdr.Read())
        {
            // get the results of each column

            allUsersString += "<tr>";
            allUsersString += "<td >" + rdr["id"] + "</td>";
            allUsersString += "<td >" + rdr["username"] + "</td>";
            allUsersString += "<td > " + rdr["email"] + "</td>";
            allUsersString += "<td > " + rdr["fname"] + "</td>";
            allUsersString += "<td > " + rdr["lname"] + "</td>";
            if ((bool)rdr["gender"])
            {
                allUsersString += "<td > " + "Male" + "</td>";
            }
            else
            {
                allUsersString += "<td > " + "Female" + "</td>";
            }
            if ((bool)rdr["admin"])
            {
                allUsersString += "<td > " + "admin" + "</td>";
            }
            else
            {
                allUsersString += "<td > " + "user" + "</td>";
            }
            allUsersString += "</tr>";
        }
        allUsersString += "</table >";
        allUsersString += "</div>";
        Response.Write(allUsersString);
        }
        else if ((string)Session["table"] == "Members of the same sex")
        {
            string gender="";
            if ((int)Session["gender"] == 0)
            {
                gender = "0";
            }
            else
            {
                gender = "1";
            }
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users WHERE gender LIKE '" + gender + "'";

            SqlDataReader rdr = cmd.ExecuteReader();
            string allUsersString = "";
            allUsersString += "<div class='container'>";
            allUsersString += "<h1>Members Of The Same Sex</h1>";
            allUsersString += "<table class=' table table-hover'>";
            allUsersString += "<tr><th>Id</th><th>Username</th><th>Email</th><th>First Name</th><th>Last Name</th><th>Gender</th><th>Type of User</th></tr>";
            while (rdr.Read())
            {
                // get the results of each column

                allUsersString += "<tr>";
                allUsersString += "<td >" + rdr["id"] + "</td>";
                allUsersString += "<td >" + rdr["username"] + "</td>";
                allUsersString += "<td > " + rdr["email"] + "</td>";
                allUsersString += "<td > " + rdr["fname"] + "</td>";
                allUsersString += "<td > " + rdr["lname"] + "</td>";
                if ((bool)rdr["gender"])
                {
                    allUsersString += "<td > " + "Male" + "</td>";
                }
                else
                {
                    allUsersString += "<td > " + "Female" + "</td>";
                }
                if ((bool)rdr["admin"])
                {
                    allUsersString += "<td > " + "admin" + "</td>";
                }
                else
                {
                    allUsersString += "<td > " + "user" + "</td>";
                }
                allUsersString += "</tr>";
            }
            allUsersString += "</table >";
            allUsersString += "</div>";
            Response.Write(allUsersString);
        }
        else
        {
            string gender = "";
            if ((int)Session["gender"] == 0)
            {
                gender = "1";
            }
            else
            {
                gender = "0";
            }
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users WHERE gender LIKE '" + gender + "'";

            SqlDataReader rdr = cmd.ExecuteReader();
            string allUsersString = "";
            allUsersString += "<div class='container'>";
            allUsersString += "<h1>Members Of The Oposite Sex</h1>";
            allUsersString += "<table class='table table-hover'>";
            allUsersString += "<tr><th>Id</th><th>Username</th><th>Email</th><th>First Name</th><th>Last Name</th><th>Gender</th><th>Type of User</th></tr>";
            while (rdr.Read())
            {
                // get the results of each column

                allUsersString += "<tr>";
                allUsersString += "<td >" + rdr["id"] + "</td>";
                allUsersString += "<td >" + rdr["username"] + "</td>";
                allUsersString += "<td > " + rdr["email"] + "</td>";
                allUsersString += "<td > " + rdr["fname"] + "</td>";
                allUsersString += "<td > " + rdr["lname"] + "</td>";
                if ((bool)rdr["gender"])
                {
                    allUsersString += "<td > " + "Male" + "</td>";
                }
                else
                {
                    allUsersString += "<td > " + "Female" + "</td>";
                }
                if ((bool)rdr["admin"])
                {
                    allUsersString += "<td > " + "admin" + "</td>";
                }
                else
                {
                    allUsersString += "<td > " + "user" + "</td>";
                }
                allUsersString += "</tr>";
            }
            allUsersString += "</table >";
            allUsersString += "</div>";
            Response.Write(allUsersString);
        }
        
    }
}