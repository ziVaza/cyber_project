<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createUser.aspx.cs" Inherits="createUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<!--#include file="Header.htm" -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
            <div class="container">
                <h1>Create account</h1><hr />
            </div>
            <form runat="server" method="post" class="container form-horizontal" role="form" onsubmit="return validateForm();">
            
            <div class="form-group">
                <label class="col-sm-2 control-label">First Name</label>
                <div class="col-sm-10">
               <input id="first_name" class="form-control" type="text" name="first_name"  placeholder="first name" value="" />    
                </div>                                
                </div>
                <div id="alert-first_name"></div><br />

                <div class="form-group">
                <label class="col-sm-2 control-label">Last Name</label>
                <div class="col-sm-10">
                <input id="last_name" type="text" class="form-control" name="last_name" placeholder="last name" value="" />
                </div>
                </div>
                <div id="alert-last_name"></div><br />

                <div class="form-group">
                <label class="col-sm-2 control-label">User Name</label>
                <div class="col-sm-10">
                <input id="user_name" type="text" class="form-control" name="user_name" placeholder="user name" value="" />
                </div>
                </div>
                <div id="alert-user_name"></div><br />

                <div class="form-group">
                <label class="col-sm-2 control-label">Password</label>
                <div class="col-sm-10">
                <input id="password" type="password" class="form-control" name="password" placeholder="password" value="" />
                </div>
                </div>
                <div id="alert-password"></div><br />

                <div class="form-group">
                <label class="col-sm-2 control-label">Confirm Password</label>
                <div class="col-sm-10">
                <input id="confirm_password" type="password" class="form-control" name="confirm_password" placeholder="confirm password" value="" />
                </div>
                </div>
                <div id="alert-confirm_password"></div><br />

                <div class="form-group">
                <label class="col-sm-2 control-label">Gender</label>
                <div class="col-sm-10">
                male: <input name="male" type="radio" class="radio" value="true" checked/>
                female:  <input name="male" type="radio" class="radio" value="false" /><br />
                </div>
                <br />
                </div>
                
                <div class="form-group">
                <label class="col-sm-2 control-label">Email</label>
                <div class="col-sm-10">
                <input type="email" name="email" class="form-control" id="email" placeholder="email" />
                </div>

                </div>
                                <div id="alert-email"></div><br />
                <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                <button type="submit" class="btn btn-primary">Sign Up</button>
                </div>
                </div>
            </form>
    
    
    <script type="text/javascript">
        function validateForm() {
            var password = document.getElementById('password').value;
            var password_confirm = document.getElementById('confirm_password').value;
            var first_name = document.getElementById('first_name').value;
            var last_name = document.getElementById('last_name').value;
            var user_name = document.getElementById('user_name').value;
            var email = document.getElementById('email').value;
            var check = true;

            if (password.length<6) {
                document.getElementById('alert-password').innerHTML = "<small class='col-sm-offset-2 col-sm-10 alert alert-danger'>Password must be at least 6 characters</small>";
                check = false;
            }
            else {
                document.getElementById('alert-password').innerHTML = "";  
            }
            if (password != password_confirm) {
                document.getElementById('alert-confirm_password').innerHTML = "<small class='col-sm-offset-2 col-sm-10 alert alert-danger'>Password and password confirm do not match!</small>";
                check = false;
            } //if
            else {
                document.getElementById('alert-confirm_password').innerHTML = "";
            } //else

            if (user_name.length < 4) {
                document.getElementById('alert-user_name').innerHTML = "<small class='col-sm-offset-2 col-sm-10 alert alert-danger'>UserName must be at least 6 characters</small>";
                check = false;
            } //if
            else {
                document.getElementById('alert-user_name').innerHTML = "";
            } //else

            if (first_name.length < 1) {
                document.getElementById('alert-first_name').innerHTML = "<small class='col-sm-offset-2 col-sm-10 alert alert-danger'>First name is too short</small>";
                check = false;
            } //if
            else {
                document.getElementById('alert-first_name').innerHTML = "";
            } //else

            if (last_name.length < 1) {
                document.getElementById('alert-last_name').innerHTML = "<small class='col-sm-offset-2 col-sm-10 alert alert-danger'>Last name is too short</small>";
                check = false;
            } //if
            else {
                document.getElementById('alert-last_name').innerHTML = "";
            } //else

            if (email.length < 1) {
                document.getElementById('alert-email').innerHTML = "<small class='col-sm-offset-2 col-sm-10 alert alert-danger'>Not a valid email</small>";
                check = false;
            }//if
            else {
                document.getElementById('alert-email').innerHTML = "";
            } //else

            if (check == false)
                return false;

            return true;
        }
    </script>
</body>
</html>
