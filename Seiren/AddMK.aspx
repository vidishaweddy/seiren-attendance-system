<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMK.aspx.cs" Inherits="AddMK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>RFA Main Menu</title>
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
        #Browse{
	        width:600px;
	        height:300px;
	        background:transparent url("../images/browseCoba.png") no-repeat;
	        float:right;
	        margin:1px;
        }
        #Admin{
	        width:210px;
	        height:300px;
	        background:transparent url("../images/adminCoba.png") no-repeat center;
	        float:left;
	        margin:1px;
	        text-align:left;
	        Border-right:solid;
	        Border-color:aqua;
        }
        #container {
	        width:860px;
	        height:330px;
	        margin:15px auto;
	        padding:10px;
	        text-align:center;
	        position:relative;
        }
        #DataGrid
        {
            margin:15px 10px 0px 10px;
        }
        body
        {
	        width:1200px;
	        padding:80px 0px 0px 0px;
        }
        #Button2
        {
            margin-top:20px;
            margin-right:30px;
        }
        #welcome_screen {
	        width:850px;
	        height:330px;
	        background:transparent url("../images/Labo-1.jpg") no-repeat;
	        padding:10px;
        }
        #menu
        {
            width:840px;
            Border-left:solid;
	        Border-color:aqua;
	        text-align:center;
	        height:320px;
	        
	        padding:30px 10px 20px 10px;
        }
        #Label4
        {
            margin-top:15px;
        }
</style>
        
        <script type="text/javascript">
	</script>
</head>
    <body>
    <form id="Form1" class="style1" runat="server">
    <div id="container">        	
            
			<!--end of main section-->
                	<div id="welcome_screen_outer1">
                        <div id="welcome_screen">
                        <div id="menu">    
                                <div id="Admin">
                                    <asp:Label ID="Label4" runat="server" Height="26px" Text="Kode Mata Pelajaran" Width="200px" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="194px" Height="20px"></asp:TextBox><asp:Label
                                        ID="Label5" runat="server" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium"
                                        Height="26px" Text="Nama Mata Pelajaran" Width="200px"></asp:Label><asp:TextBox ID="TextBox2"
                                            runat="server" Height="20px" Width="194px"></asp:TextBox><asp:Label ID="Label6" runat="server"
                                                Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium" Height="26px"
                                                Text="Jumlah SKS" Width="200px"></asp:Label><asp:TextBox ID="TextBox3" runat="server"
                                                    Height="20px" Width="194px"></asp:TextBox>
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Height="26px" Text="Semester Mata Pelajaran" Width="200px"></asp:Label>
                                    <asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="194px"/></div>
                                <div id="Browse" style="width: 615px">
                                <asp:DataGrid id="DataGrid"  AutoGenerateColumns="False" AllowSorting="True" runat="server" CellPadding="3" GridLines="Vertical" Height="35px" Width="575px" Font-Bold="False" Font-Italic="False" Font-Names="Comic Sans MS" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" AllowPaging="True" >
											<SelectedItemStyle ForeColor="White" BackColor="#008A8C" Font-Bold="True"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Bisque" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
											<HeaderStyle Font-Bold="True" BackColor="RoyalBlue" Font-Names="Tahoma" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" Wrap="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
											<FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>
											<Columns>
                                                    <asp:BoundColumn HeaderText="Kode Mata Pelajaran"
                                                    SortExpression="Kode Mata Pelajaran" 
                                                      DataField="Kode Mata Pelajaran" />
                                                    <asp:BoundColumn HeaderText="Nama Mata Pelajaran" 
                                                    SortExpression="Nama Mata Pelajaran"
                                                      DataField="Nama Mata Pelajaran" />
                                                    <asp:BoundColumn HeaderText="Jumlah SKS"
                                                    SortExpression="Jumlah SKS" 
                                                      DataField="Jumlah SKS" />
                                                      <asp:BoundColumn HeaderText="Semester"
                                                    SortExpression="Semester" 
                                                      DataField="Semester" />
                                            </Columns>
											<PagerStyle HorizontalAlign="Center" VerticalAlign="Top" ForeColor="White" BackColor="RoyalBlue" Font-Names="Comic Sans MS" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Mode="NumericPages"></PagerStyle>
                                            <ItemStyle Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Snow" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
										</asp:DataGrid>
                                </div>
                            <asp:Button ID="Button2" runat="server" Text="Confirm" Width="150px" Height="28px" OnClick="Button2_Click" />
                            <asp:Button ID="Button3" runat="server" Text="Cancel" Width="150px" Height="28px" OnClick="Button3_Click" /></div>
                        </div>
                 </div>
           
			<div id="main">
                  <div id="footer">
            </div>
    	</div>
            </div><!--end of container section-->
            </form>
</body>
</html>



