<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!--#include file="Header.htm" -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>

<div class="container">
    <h1>Login</h1>
    <form id="form1" class="form-horizontal" runat="server" method="get">
    <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">Username</label>
    <div class="col-sm-10">
    <input id="Text1" type="text" placeholder="Username" name="Username" /><br />
    </div>
    </div>

    <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">Password</label>
    <div class="col-sm-10">
    <input id="Text2" type="password" placeholder="Password" name="Password"/><br />
    </div>
    </div>

      <div class="form-group">
      <div class="col-sm-offset-2 col-sm-10">
     <button type="submit" class="btn btn-success">Login</button>
     </div>
     </div>
    </form>

    <div class="col-sm-offset-2 col-sm-10">
    <a href="createUser.aspx"><p>If you dont have an account press here to sign up!</p></a>
    </div>
    </div>
</body>
</html>
