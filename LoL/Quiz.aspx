<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quiz.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!--#include file="Header.htm" -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
    <h1>Quiz</h1>

    <h4>What company made League of Legends?</h4>
    <input  name="q1" id="q1a1" type="radio"/>Riot Games<br />
    <input  name="q1" id="q1a2" type="radio"/>Microsoft<br />
    <input  name="q1" id="q1a3" type="radio"/>Ubisoft<br />
    <input  name="q1" id="q1a4" type="radio"/>EA<br />

    <h4>How many lanes are there in The Twisted Treeline?</h4>
    <input name="q2" id="q2a1" type="radio"/>3<br />
    <input name="q2" id="q2a2" type="radio"/>1<br />
    <input name="q2" id="q2a3" type="radio"/>2<br />
    <input name="q2" id="q2a4" type="radio"/>what is a lane?<br />
    
    <h4>How many champions are there?</h4>
    <input name="q3" id="q3a1" type="radio"/>117<br />
    <input name="q3" id="q3a2" type="radio"/>122<br />
    <input name="q3" id="q3a3" type="radio"/>97<br />
    <input name="q3" id="q3a4" type="radio"/>118<br />

    <h4>How many items are currently in the game(the sum of all items in all maps no duplicates)?</h4>
    <input name="q4" id="q4a1" type="radio"/>82<br />
    <input name="q4" id="q4a2" type="radio"/>134<br />
    <input name="q4" id="q4a3" type="radio"/>177<br />
    <input name="q4" id="q4a4" type="radio"/>94<br />
    <input id="Button1" type="button" class="btn btn-success" value="Send Answers!" onclick="check();"/>
    </div>

    <script type="text/javascript">

        function check() {
            var score = 0;
            if (document.getElementById('q1a1').checked) {
                score += 25;
            }
            if (document.getElementById('q2a3').checked) {
                score += 25;
            }
            if (document.getElementById('q3a4').checked) {
                score += 25;
            }
            if (document.getElementById('q4a3').checked) {
                score += 25;
            }
          alert("You scored " + score + " points");
        }
    </script>
</body>
</html>
