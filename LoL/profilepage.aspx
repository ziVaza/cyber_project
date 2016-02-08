<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profilepage.aspx.cs" Inherits="profilepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!--#include file="Header.htm" -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <div class='container'>
    <form id="form1" runat="server">
    
        <%
        if ((string)Session["admin"]=="false")
        {
         string profilenav=""; 
        profilenav+="<ul>";
        profilenav += "<li class='smallnav'><a href='Update.aspx' class='btn btn-success'>Update</a></li>";
        profilenav += "<li class='smallnav'><a href='ShowUsers.aspx' class='btn btn-primary'>Show Users</a></li>";
        profilenav += "<li class='smallnav'><a href='DeleteUser.aspx' class='btn btn-danger'>Delete My Account!</a></li>";
        profilenav += "<li class='smallnav'><a href='LogOut.aspx' class='btn btn-warning'>Log Out</a></li>";
        profilenav+="</ul>";
        Response.Write(profilenav);
        }
        if ((string)Session["admin"] == "true")
        {
            string profilenav = "";
            profilenav += "<ul>";
            profilenav += "<li class='smallnav'><a class='btn btn-success' href='Update.aspx'>Update</a></li>";
            profilenav += "<li class='smallnav'><a class='btn btn-primary' href='ShowUsers.aspx'>Show Users</a></li>";
            profilenav += "<li class='smallnav'><a class='btn btn-primary' href='DeleteOtherAccounts.aspx'>Delete Users</a></li>";
            profilenav += "<li class='smallnav'><a class='btn btn-primary' href='UserToAdmin.aspx'>Make Users Admins</a></li>";
            profilenav += "<li class='smallnav'><a class='btn btn-danger' href='DeleteUser.aspx' onclick='return deleteAlert()'>Delete My Account!</a></li>";
            profilenav += "<li class='smallnav'><a class='btn btn-warning' href='LogOut.aspx' onclick=' return logoutAlert()'>Log Out</a></li>"; 
            profilenav += "</ul>";
            Response.Write(profilenav);
        }
        
        
         %>
    </form>
    </div>
    <script type="text/javascript">
        function deleteAlert() {
            if (confirm("You are about to delete your account. Do you wish to proceed?")) {
                return true;
            }
            else {
                return false;
            }
        }

        function logoutAlert() {
            if (confirm("You are about to log out of your account. Do you wish to proceed?")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</body>
</html>
