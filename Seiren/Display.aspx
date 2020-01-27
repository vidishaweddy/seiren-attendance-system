<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Display.aspx.cs" Inherits="Display" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
<title>Display Software Detail</title>
<style type="text/css">
#container {
	width:970px;
	background:#00496c;
	margin:15px auto;
	text-align:left;
	position:relative;
}
body {
	background-color:#00496c;
	font: 11px Verdana, Arial, Helvtica, sans-serif;
	text-align:center;
	margin:0px;
}
#header {
	width:500x;
	height:140px;
	background:url("../images/logoNew.png") no-repeat top center;
	margin:0px;
}
#f2{
    clear: both;
    border-color: #fff ;
    border-width: 2px;
    border-style: solid; 
    padding: 10px;
    margin: 0px;
}

#div1,#div3,#lab3,#d3,#div4{ 
	width:220px;
	height:6px;
	float:left;
	margin:5px 0px 4px 0px;
	padding:0px 0px 0px 0px;
	font: 10px Comic Sans;
	color:#000;
}
#LabelProv
{
width:220px;
	height:6px;
	margin:5px 0px 0px 0px;
	font: 10px Comic Sans;
	color:#f00;
}

#lab4{ 
	width:220px;
	height:6px;
	float:left;
	margin:5px 0px 4px 0px;
	padding:0px 0px 0px 0px;
	font: 10px Comic Sans;
	color:#000;
}
#Label49 a
{
float:right;
font:bold 12px Tahoma;
color: #fff;
}
#Label49 a:hover
{
color:#33ffff;
}
</style>
        <script type="text/javascript">
function startTimer() {
setInterval(onTick,300000); // every second
}
function onTick() {
document.location.reload();
}
</script>

</head>
<body onload="startTimer();">
<form id="Form1" class="style1" runat="server" method="post">
<div id="header" style="background-image: url(images/logoNew.png); width: 993px; height: 200px; background-position: center top; position: static;"></div>
    &nbsp;&nbsp;<fieldset id="f2" style="width: 968px; height: 295px; background-position: center top; background-attachment: fixed; background-image: url(images/logo-1.png); background-repeat: no-repeat;">

    <label id="Label2"><span style="color: aqua; font-weight: bold; font-size: 20pt; font-family: Tahoma;">Detil Absensi Matakuliah</span></label>
    <label id="Label5"><span style="color: aqua; font-weight: bold; font-size: 20pt; font-family: Tahoma;"></span></label>
    <h1 style="text-align: left">
        <label>
            <label id="Label49" style="font-size: 10pt; font-family: Tahoma">
                <a href="Browse.aspx"><<--Back to Table</a>
                <asp:Image ID="Image2" runat="server" Height="104px" Width="102px" /></label><br />
    <label id="div3" style="height: 141px; font-size: 10pt; font-family: Tahoma; width: 361px;">
        <asp:Label ID="Label7" Text="Nama" runat="server" Height="18px" Font-Bold="True" Width="218px" ForeColor="#33FFFF"/><br />
        <asp:Label ID="Label10" Text="Nomor Induk" runat="server" width="220px" Height="18px" Font-Bold="True" ForeColor="#33FFFF"/><br />
<asp:Label ID="S_2" Text="Semester" runat="server" width="220px" Height="17px" Font-Bold="True" ForeColor="#33FFFF"/><br />
        <asp:Label ID="Label3" Text="Matakuliah" runat="server" width="219px" Height="18px" Font-Bold="True" ForeColor="#33FFFF"/>
        <asp:Label ID="Label4" Text="Kode MK" runat="server" width="220px" Height="18px" Font-Bold="True" ForeColor="#33FFFF"/><br />
        <asp:Label ID="Label1" Text="Jumlah SKS" runat="server" width="220px" Height="14px" Font-Bold="True" ForeColor="#33FFFF"/>
        &nbsp; &nbsp; &nbsp;&nbsp;
        </label><label id="div4" style="font-size: 10pt; font-family: Tahoma; height: 142px;"><asp:Label ID="TextBox29" runat="server" Height="18px" Width="337px" Font-Bold="True" ForeColor="#FFFFFF"></asp:Label><br />
        <asp:Label ID="TextBox2" runat="server" Width="336px" Font-Bold="True" Height="18px" ForeColor="#FFFFFF" /><br />
<asp:Label ID="TextBox6" runat="server" Width="334px" Height="19px" Font-Bold="True" ForeColor="#FFFFFF" /><br />
   <asp:Label id="labPub" runat="server" Font-Bold="True" Height="14px" Width="334px" ForeColor="#FFFFFF" /><br />
<asp:Label id="labDomain" runat="server" Font-Bold="True" Height="17px" Width="334px" ForeColor="#FFFFFF" /><asp:Label id="Label12" runat="server" Font-Bold="True" Height="17px" Width="333px" ForeColor="#FFFFFF" /><br />
            </label><span style="font-size: 10pt; font-family: Tahoma">&nbsp;</span><span style="font-size: 10pt; font-family: Tahoma"><br />


</span></label></h1>
      
</fieldset>
&nbsp;
</form>
</body>
</html>
