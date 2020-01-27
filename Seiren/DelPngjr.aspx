<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DelPngjr.aspx.cs" Inherits="DelPngjr" %>

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
        #New{
	        width:250px;
	        height:480px;
	        background:transparent url("../images/newCoba.png") no-repeat;
	        float:left;
	        Border-right:solid;
	        Border-color:aqua;
	        text-align:center;
	        margin:3px;
        }
        #image{
        width:165px;
        height:200px;
        margin:10px auto 5px;
        align:center;
        border:solid;
        border-width:1px;
        }
        #imageFinger{
        width:165px;
        height:200px;
        margin:0px auto 25px;
        border:solid;
        border-width:1px;
        }
        #imageBarcode{
        width:230px;
        height:50px;
        margin:0px auto 10px;
        border:solid;
        border-width:1px;
        }
        #Label1{
        margin-top:10px;
        }
        #Label2{
        margin-bottom:10px;
        }
        #Label3{
        margin-bottom:10px;
        }
        #Browse{
	        width:615px;
	        height:480px;
	        background:transparent url("../images/browseCoba.png") no-repeat;
	        float:right;
	        margin:3px;
	        text-align:center;
        }
        #Admin{
	        width:210px;
	        height:480px;
	        background:transparent url("../images/adminCoba.png") no-repeat center;
	        float:left;
	        margin:3px;
	        Border-right:solid;
	        Border-color:aqua;
	        text-align:left;
        }
        #container {
	        width:1190px;
	        height:520px;
	        margin:15px auto;
	        text-align:center;
	        position:relative;
	        padding:5px;
        }

        body
        {
	        width:1200px;
	        text-align:center;
	        padding:80px 0px 0px 0px;
        }
        #welcome_screen {
	        width:1110px;
	        height:515px;
	        background:transparent url("../images/Labo-1.jpg") no-repeat;
	        padding:10px 10px 10px 80px;
        }
        #menu
        {
            width:1100px;
	        height:510px;
	        text-align:center;
	        Border-left:solid;
	        Border-color:aqua;
	        padding:30px 10px 20px 10px;
        }
        #Button2
        {
            margin-top:20px;
            margin-right:30px;
        }
        #Label4
        {
            margin-top:10px;
        }
        #DataGrid
        {
            margin:15px 10px 0px 10px;
        }
        #FileUpload1{
            margin-bottom:25px;
        }
        #ButtonShow{
        margin-bottom:10px
        }
        #mk
        {
            float:right;
            margin-top:5px;
        }
        
</style>
        <link rel="stylesheet" href="css/date_picker.css" type="text/css" media="screen" />
        <script src="js/jquery-1.2.6.js" type="text/javascript"></script>
        <script src="js/jdate_picker.js" type="text/javascript"></script>
        <script type="text/javascript">
        
        function deconly(e){
            var code;
            if (!e) var e = window.event;
            if (e.keyCode) code = e.keyCode;
            else if (e.which) code = e.which;
            var character = String.fromCharCode(code);
            var AllowRegex  = /^[\b0-9.\s-]$/;
            if (AllowRegex.test(character)) return true;    
            return false;
        }
        
        function numonly(e){
            var code;
            if (!e) var e = window.event;
            if (e.keyCode) code = e.keyCode;
            else if (e.which) code = e.which;
            var character = String.fromCharCode(code);
            var AllowRegex  = /^[\b0-9\s-]$/;
            if (AllowRegex.test(character)) return true;    
            return false;
        }
        
        $(document).ready(function(){
        $('#TextBox4').datepicker({dateFormat: 'dd-mm-yy', firstDay: 1});
        });
	</script>
</head>
    <body>
    <form id="Form1" class="style1" runat="server">
    <div id="container">        	
            
			<!--end of main section-->
                	<div id="welcome_screen_outer1">
                        <div id="welcome_screen">
                        <div id="menu">              
                                <div id="New">
                                    <asp:Label ID="Label1" runat="server" Text="Foto Pengajar" Width="148px" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium" ></asp:Label>
                                    <div id="image">
                                        <asp:Image ID="Image1" runat="server" Height="196px" Width="159px" />
                                        </div>
                                        <asp:Button ID="ButtonShow" Text="Tampilkan Gambar" runat="server" Width="160px" Visible="true" OnClick="ButtonShow_Click" />
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="220px" />
                                    &nbsp;
                                </div>
                                <div id="Admin">
                                    <asp:Label ID="Label4" runat="server" Height="26px" Text="Nomor Induk" Width="200px" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="135px" Height="20px"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="Cek" Width="56px" OnClick="Button1_Click" />
                                    <asp:Label
                                        ID="Label5" runat="server" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium"
                                        Height="26px" Text="Nama Pengajar" Width="200px"></asp:Label><asp:TextBox ID="TextBox2"
                                            runat="server" Height="20px" Width="194px"></asp:TextBox><asp:Label ID="Label6" runat="server"
                                                Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium" Height="26px"
                                                Text="Tempat Lahir" Width="200px"></asp:Label><asp:TextBox ID="TextBox3" runat="server"
                                                    Height="20px" Width="194px"></asp:TextBox>
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Height="26px" Text="Tanggal Lahir" Width="200px"></asp:Label>
                                    <input id="TextBox4" name="TextBox4" runat="server" readonly="true" style="height:20px; width:194px" type="text"/><asp:Label
                                        ID="Label8" runat="server" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium"
                                        Height="26px" Text="Agama" Width="200px"></asp:Label><asp:TextBox ID="TextBox5" runat="server"
                                            Height="20px" Width="194px"></asp:TextBox><br />
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Height="27px" Text="Nomor Telepon" Width="200px"></asp:Label><asp:TextBox
                                            ID="TextBox6" runat="server" Height="20px" Width="194px"></asp:TextBox><br />
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Height="27px" Text="Alamat" Width="200px"></asp:Label><asp:TextBox
                                            ID="TextBox7" runat="server" Height="20px" Width="194px"></asp:TextBox><br />
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Height="27px" Text="Email" Width="200px"></asp:Label><asp:TextBox
                                            ID="TextBox8" runat="server" Height="20px" Width="194px"></asp:TextBox><br />
                                    </div>
                                <div id="Browse" style="width: 615px">
                                <asp:DataGrid id="DataGrid"  AutoGenerateColumns="False" AllowSorting="True" runat="server" CellPadding="3" GridLines="Vertical" Height="35px" Width="575px" Font-Bold="False" Font-Italic="False" Font-Names="Comic Sans MS" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" AllowPaging="True" PageSize="20" >
											<SelectedItemStyle ForeColor="White" BackColor="#008A8C" Font-Bold="True"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Bisque" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
											<HeaderStyle Font-Bold="True" BackColor="RoyalBlue" Font-Names="Tahoma" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" Wrap="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
											<FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>
											<Columns>
                                                    <asp:BoundColumn HeaderText="Nomor Induk"
                                                    SortExpression="Nomor Induk" 
                                                      DataField="Nomor Induk" />
                                                    <asp:BoundColumn HeaderText="Nama Pengajar" 
                                                    SortExpression="Nama Pengajar"
                                                      DataField="Nama Pengajar" />
                                                    <asp:BoundColumn HeaderText="No Telepon"
                                                    SortExpression="No Telepon" 
                                                      DataField="No Telepon" />
                                                      <asp:BoundColumn HeaderText="Alamat"
                                                    SortExpression="Alamat" 
                                                      DataField="Alamat" />
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

