<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Software License Management Main Menu</title>
    <meta name="author" content="vbv_70807" />
         <meta name="description" content="RFA website" />
        <meta name="keyword" content="Request,Analysis,RFA,online" />
        <meta name="robots" content="all" />
        <meta name="googlebot" content="all" />
        <meta name="revisit-after" content="2 days" />
        <meta name="expires" content="never" />
        <meta name="webcrawlers" content="all" />
        <meta name="rating" content="commercial" />
        <meta name="spiders" content="all" />
        <style type="text/css">
  
        #container {
	width:970px;
	background:#fff;
	margin:15px auto;
	text-align:left;
	position:relative;
}
body {
	background-color:#fff;
	font: 11px Verdana, Arial, Helvtica, sans-serif;
	text-align:center;
	width: 600px;
	margin: 520px auto auto 600px;
}        


#tour{
	width:850px;
	float:left;
}
#Browse{
	width:400px;
	height:188px;
	background:transparent url("../images/browseCoba.png") no-repeat;
	float:right;
	margin:auto;
}

        </style>
        <script type="text/javascript">
        
		function textnumonly(e){
var code;
if (!e) var e = window.event;
if (e.keyCode) code = e.keyCode;
else if (e.which) code = e.which;
var character = String.fromCharCode(code);
    var AllowRegex  = /^[\b0-9a-zA-Z\s-]$/;
    if (AllowRegex.test(character)) return true;    
    return false;
}
	</script>
</head>
    <body style="background-attachment: fixed; background-image: url(images/Home.png); background-repeat: no-repeat; background-position: center center;">
    <form id="Form1" class="style1" runat="server">
        <asp:Label ID="Label1" Text="Username" runat="server" Width="115px" Height="18px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="13px" Width="158px"></asp:TextBox><br />
        &nbsp;<asp:Label ID="Label2" Text="Password" runat="server" Width="115px" Height="18px"></asp:Label>
        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" Height="13px" Width="158px"></asp:TextBox>&nbsp;<br />
        <asp:Button
            ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" Width="76px" />
            </form>
</body>
</html>
