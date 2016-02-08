using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"]==null)
        {
            if (Page.IsPostBack)
            {
                string username = Request.QueryString["Username"];
                string password = Request.QueryString["Password"];
                string connectionstring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";

                SqlConnection connection = new SqlConnection(connectionstring);


                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(username) FROM users WHERE username LIKE'" + username + "' AND password LIKE '"+password+"'";
                cmd.Connection = connection;
                connection.Open();
                int x = (int)cmd.ExecuteScalar();
                if (x == 0)
                {
                  Response.Write("<script>alert('Username and Password dont match');</script>");
                }
                else
                {
                    Session["username"] = username;
                    cmd.CommandText = "SELECT gender FROM users WHERE username LIKE'" + username + "'";
                    Session["gender"] = cmd.ExecuteNonQuery();
                    Response.Redirect("profilepage.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("profilepage.aspx");
        }
    }
}