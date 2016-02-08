using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DeleteUsersaccountformanager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        string sqlstring = "SELECT * FROM users";
        cmd.CommandText = sqlstring;
        SqlDataReader rdr = cmd.ExecuteReader();
        string html = "";
        html += "<div class='container'>";
        html += "<h1> Delete Users </h1>";
        while (rdr.Read()) 
        {
            html += "<form id='form1' method='get' action='DeleteTotalFromManager.aspx'>";
            html += "<input id='Hidden1' type='hidden' name='username' value='"+rdr["username"]+"' /><br/>";
            html += "Username: "+rdr["username"]+"</br>";
            html += "<input id='Submit1' type='submit' class='btn btn-danger' value='DELETE'/>";
            html += "</form>";
        }//while
        html += "</div>";
        Response.Write(html);
        }//if !postback
    }
}