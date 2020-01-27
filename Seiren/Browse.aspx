<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Browse Software</title>
    <script type="text/javascript">
function startTimer() {
setInterval(onTick,300000); // every second
}
function onTick() {
document.location.reload();
}
</script>
        <style type="text/css">
        #searchList,#Label3,#Label4,#Label5,#Label6
{
    width:220px;
	height:6px;
	float:left;
	margin:5px 20px 0px 20px;
	font: 10px Comic Sans;
	color:#f00;
}
#searchList,#Label7
{
margin:5px 20px 0px 105px;
}
#LabelSearch
{
text-align:center;
}
body {
	background-color:#00496c;
	font: 11px Verdana, Arial, Helvtica, sans-serif;
	text-align:center;
	margin:0px;
}
#Label6
{
margin:5px 20px 10px 105px;
}
#DropDownList2
{
font: 8pt Verdana;
}
#header{
width:970px;
margin:15px auto;
position:relative;
}
#container {
	width:970px;
	background:#00496c;
	margin:15px auto;
	text-align:left;
	position:relative;
}
#form1
{
background :url("../images/Logo.png") no-repeat top center;
}
        </style>
</head>
<body onload="startTimer();">
    <div id="header" style="width: 970px; background-image: url(images/logoNew.png); background-repeat: no-repeat; height: 202px; background-color: white; position: static;"></div>
<div id="container" style="left: 0px; top: -16px; height: 843px; text-align: center; width: 966px; background-position: left top; background-attachment: fixed; background-image: url(images/logo-1.png); background-repeat: no-repeat; border-right: #ffffff 2px solid; border-top: #ffffff 2px solid; border-left: #ffffff 2px solid; border-bottom: #ffffff 2px solid;">     	
    <form id="form1" runat="server">
        <label id="Label7" style="width: 760px; text-align: center;">
            <br />
            <asp:Image ID="Image2" runat="server" Height="125px" Width="134px" /><br />
            &nbsp;<asp:Label ID="Label8" runat="server" Text="Nama" Width="90px"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="Label" Width="130px"></asp:Label><br />
            <asp:Label ID="Label10" runat="server" Text="Nomor Induk" Width="90px"></asp:Label>
            <asp:Label ID="Label11" runat="server" Text="Label" Width="130px"></asp:Label><br />
            <asp:Label ID="Label12" runat="server" Text="Fakultas" Width="90px"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text="Label" Width="130px"></asp:Label><br />
            <asp:Label ID="Label15" runat="server" Text="Prodi" Width="90px"></asp:Label>
            <asp:Label ID="Label17" runat="server" Text="Label" Width="130px"></asp:Label><br />
            <asp:Label ID="Label18" runat="server" Text="Semester" Width="90px"></asp:Label>
            <asp:Label ID="Label19" runat="server" Text="Label" Width="130px"></asp:Label><br />
            <br />
            &nbsp;</label>&nbsp;
    <asp:DataGrid id="DataGridSLM"  AutoGenerateColumns="False" AllowSorting="True" runat="server" CellPadding="3" GridLines="Vertical" Height="10px" Width="708px" Font-Bold="False" Font-Italic="False" Font-Names="Comic Sans MS" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" AllowPaging="True" PageSize="35" >
											<SelectedItemStyle ForeColor="White" BackColor="#008A8C" Font-Bold="True"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Bisque" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
											<HeaderStyle Font-Bold="True" BackColor="RoyalBlue" Font-Names="Tahoma" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" Wrap="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
											<FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>
											<Columns>
                                                    <asp:HyperLinkColumn HeaderText="Kode Matakuliah"
                                                    DataNavigateUrlField="KodeMatakuliah"
                                                    DataNavigateUrlFormatString="Display.aspx?Software Name={0}"
                                                    SortExpression="KodeMatakuliah" 
                                                      DataTextField="KodeMatakuliah" />
                                                    <asp:BoundColumn HeaderText="Nama Matakuliah" 
                                                    SortExpression="NamaMatakuliah"
                                                      DataField="NamaMatakuliah" />
                                                    <asp:BoundColumn HeaderText="Jumlah Pertemuan"
                                                    SortExpression="Jumlah" 
                                                      DataField="Jumlah" />
                                                      <asp:BoundColumn HeaderText="Masuk"
                                                    SortExpression="Masuk" 
                                                      DataField="Masuk" />
                                            </Columns>
											<PagerStyle HorizontalAlign="Center" VerticalAlign="Top" ForeColor="White" BackColor="RoyalBlue" Font-Names="Comic Sans MS" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Mode="NumericPages"></PagerStyle>
                                            <ItemStyle Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Snow" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
										</asp:DataGrid><br />
    </form>
    </div>
</body>
</html>
