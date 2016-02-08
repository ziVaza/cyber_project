using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            string user_name = Request.Form["user_name"];
            string first_name = Request.Form["first_name"];
            string last_name = Request.Form["last_name"];
            string password = Request.Form["password"];
            string male = Request.Form["male"];
            string email = Request.Form["email"];
            

            
            SqlUtility util = new SqlUtility();
            if (util.CreateUser(user_name, first_name, last_name, password, male, email))
            {
                Session["username"] = user_name;
                Response.Redirect("profilepage.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('user already exists')</script>");
            }
        }//if
    }
}