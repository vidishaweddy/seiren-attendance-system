<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetMKforPngjr.aspx.cs" Inherits="GetMKforPngjr" %>

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
        #container {
	        width:1051px;
	        margin:15px auto;
	        text-align:center;
	        position:relative;
        }

        body
        {
            height:100px;
	        width:1200px;
	        padding:80px 0px 0px 0px;
        }
        #welcome_screen {
	        width:1051px;
	        height:200px;
	        background:transparent url("../images/Labo-1.jpg") no-repeat;
	        padding:50px 10px 50px 10px;
        }
        #menu
        {
            width:1051px;
	        height:190px;
	        border-left:solid;
	        border-bottom:solid;
	        border-color:aqua;
	        padding:50px 10px 50px 10px;
        }
        #GridView1
        {
            padding:5px auto;
            margin: 5px auto;
            postion:fixed;
        }
        #Button2
        {
            margin-right: 10px;
        }
        #
</style>
        <script src="js/jquery-1.2.6.js" type="text/javascript"></script>
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
                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                Font-Size="Medium" ForeColor="Black" Height="22px" Text="Pilih Mata Pelajaran yang diambil Pelajar"
                                Width="400px"></asp:Label>
                            <br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" Height="36px" Width="682px">
                                <Columns>
                                    <asp:BoundField DataField="Kode Mata Pelajaran" HeaderText="Kode Mata Pelajaran" />
                                    <asp:BoundField DataField="Nama Mata Pelajaran" HeaderText="Nama Mata Pelajaran" />
                                    <asp:BoundField DataField="Kelas" HeaderText="Kelas" />
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkInsert" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            &nbsp;
                            <br />
                            <asp:Button ID="Button2" runat="server" Text="Lanjutkan" Width="91px" OnClick="Button2_Click" />
                            <asp:Button ID="Button3" runat="server" Text="Batalkan" Width="91px" OnClick="Button3_Click"/></div>
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


