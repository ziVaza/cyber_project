using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ShowUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\LoL\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
            string username = Session["username"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users WHERE username LIKE '" + username + "'";

            SqlDataReader rdr = cmd.ExecuteReader();
            string formTouser = "";
            formTouser += "<form id='form1' class='form-horizontal' action='Updatethedetails.aspx' method='get'>";
            while (rdr.Read())
            {
                // get the results of each column
                formTouser += "<input  id='Text1' type='hidden' name='id' value=" + rdr["id"] + " />" + "<br />";

                formTouser += "<div class='form-group'>";
                formTouser += "<label class='col-sm-2 control-label'>Username</label>";
                formTouser += "<div class='col-sm-10'>";
                formTouser += "<input id='Text1' type='text' class='form-control' name='username' value=" + rdr["username"] + " /><br />";
                formTouser += "</div>";
                formTouser += "</div>";

                formTouser += "<div class='form-group'>";
                formTouser += "<label class='col-sm-2 control-label'>Password</label>";
                formTouser += "<div class='col-sm-10'>";
                formTouser += "<input id='Text1' type='text' class='form-control' name='password' value=" + rdr["password"] + " /><br />";
                formTouser += "</div>";
                formTouser += "</div>";

                formTouser += "<div class='form-group'>";
                formTouser += "<label class='col-sm-2 control-label'>First Name</label>";
                formTouser += "<div class='col-sm-10'>";
                formTouser += "<input id='Text1' type='text' class='form-control' name='fname' value=" + rdr["fname"] + " /><br />";
                formTouser += "</div>";
                formTouser += "</div>";

                formTouser += "<div class='form-group'>";
                formTouser += "<label class='col-sm-2 control-label'>Last Name</label>";
                formTouser += "<div class='col-sm-10'>";
                formTouser += "<input id='Text1' type='text' class='form-control' name='lname' value=" + rdr["lname"] + " /><br />";
                formTouser += "</div>";
                formTouser += "</div>";

                formTouser += "<div class='form-group'>";
                formTouser += "<label class='col-sm-2 control-label'>Email</label>";
                formTouser += "<div class='col-sm-10'>";
                formTouser += "<input id='Text1' type='text' class='form-control' name='email' value=" + rdr["email"] + " /><br />";
                formTouser += "</div>";
                formTouser += "</div>";
                

            }

            formTouser+="<div class='form-group'>";
            formTouser+="<div class='col-sm-offset-2 col-sm-10'>";
            formTouser+="<button type='submit' class='btn btn-success'>Update</button>";
            formTouser+="</div>";
            formTouser += "</div>";
            formTouser += "</form>";
            Response.Write(formTouser);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}