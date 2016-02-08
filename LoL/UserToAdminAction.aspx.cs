using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class UserToAdminAction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.QueryString["username"];
        string connectionstring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
        SqlConnection connection = new SqlConnection(connectionstring);
        connection.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE users SET admin='True' WHERE username='"+username+"'";
        cmd.ExecuteNonQuery();
        Response.Redirect("UserToAdmin.aspx");
    }
}