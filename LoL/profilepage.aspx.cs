using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class profilepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["admin"] = "";
        if (Session["username"] != null)
        {   
            string username = (string)Session["username"];
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users WHERE username LIKE '"+username+"'";

            SqlDataReader rdr = cmd.ExecuteReader();
            string allUsersString = "";
            allUsersString += "<div class='container'>";
            allUsersString += "<table border=1 class='table'>";
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
                    Session["admin"] = "true";
                }
                else
                {
                    allUsersString += "<td > " + "user" + "</td>";
                    Session["admin"] = "false";
                }
                allUsersString += "</tr>";
            }
            allUsersString += "</table >";
            allUsersString += "</div>";
            Response.Write(allUsersString);

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }   
}