using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Updatethedetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.QueryString["username"];
        string password = Request.QueryString["password"];
        string email = Request.QueryString["email"];
        string fname = Request.QueryString["fname"];
        string lname = Request.QueryString["lname"];
        string id = Request.QueryString["id"];

        string connectionstring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
        SqlConnection connection = new SqlConnection(connectionstring);
        connection.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE users SET fname='" + fname + "', lname='" + lname + "', username='" + username + "', email='" + email + "', password='" + password + "' WHERE id='" + id + "'";
        cmd.ExecuteNonQuery();
        Response.Redirect("Showusers.aspx");
    }
}