<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!--#include file="Header.htm" -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">  
    <h1>Gallery</h1>
    <center>
    <img src="img/LoL.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/LoL.jpg');"/>
    <img src="img/riot-1318450508.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/riot-1318450508.jpg');" />
    <img src="img/download.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/download.jpg');" /><br />
    <img src="img/League-of-legends-3.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/League-of-legends-3.jpg');" />
    <img src="img/League-of-legends-image-league-of-legends-36523309-1191-670.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/League-of-legends-image-league-of-legends-36523309-1191-670.jpg');" />
    <img src="img/League-of-legends-image-league-of-legends-36523311-1920-1080.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/League-of-legends-image-league-of-legends-36523311-1920-1080.jpg');" /><br />
    <img src="img/League-of-legends-image-league-of-legends-36523313-1024-576.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/League-of-legends-image-league-of-legends-36523313-1024-576.jpg');" />
    <img src="img/league_of_legends_i_am_top_wallpaper_a_wallpaper_by_nibblesmekibbles-d64x43v.jpg" alt="Alternate Text" style=" height:100px; width:100px;" onmouseover="changeimg('img/league_of_legends_i_am_top_wallpaper_a_wallpaper_by_nibblesmekibbles-d64x43v.jpg');"/><br />
    <img id="bigimg" src="img/blank.gif" alt="" style=" height:500px; width:500px; " />
    </center>
    </div>
    <script type="text/javascript">
        function changeimg(img) {
            var bigimg = document.getElementById("bigimg");
            bigimg.src = img;
        }
    
    
    
    
    
    </script>
</body>
</html>
