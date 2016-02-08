<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="ShowUsers.aspx.cs" Inherits="ShowUsers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!--#include file="Header.htm" -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
    <form id="form1" action="#" runat="server">
        <select id="Select1" name="table">
        <option>All users</option>
        <option>Members of the same sex</option>
        <option>Members of the oposite sex</option>
        </select>
         <input id="Submit1" type="submit" class="btn btn-success" value="Select Table" />
    </form>
    </div>
</body>
</html>
