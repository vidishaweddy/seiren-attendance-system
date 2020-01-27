<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tambahkelas.aspx.cs" Inherits="Tambahkelas" %>

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
            width:350px;
	        height:730px;
	        border-left:solid;
	        border-color:aqua;
	        padding:10px 10px 50px 10px;
	        margin:auto;
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
        #new
        {
            width:323px;
            height:900px;
            margin: auto;
            float:left;
            padding:2px;
        }
        #tombol
        {
            width:300px;
            height:25px;
            margin:10px auto;
            float:left;
        }
</style>
        <script src="js/jquery-1.2.6.js" type="text/javascript"></script>
        <script type="text/javascript">
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
                                Font-Size="Medium" ForeColor="Black" Height="22px" Text="Input Jumlah kelas dari mata pelajaran ini"
                                Width="332px"></asp:Label><br />
                            <br />
                            <asp:TextBox ID="TextBoxjumlah" runat="server" Width="100px"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lanjutkan"
                                Width="95px" /><br />
                                <div id="tombol">
                            <asp:Button ID="Button2" runat="server" Text="Lanjutkan" Height="25px" OnClick="Button2_Click" /><asp:Button ID="Button3" runat="server" Text="Batalkan" Height="25px" OnClick="Button3_Click" /></div>
                                <div id="new" style="height: 99px">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Text="Kelas" Width="54px"></asp:Label><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Text="Hari" Width="100px"></asp:Label><asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Text="Sesi" Width="100px"></asp:Label><asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Comic Sans MS"
                                        Font-Size="Medium" Text="Ruang" Width="56px"></asp:Label><br />
                            
                            <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList ID="DropDownList1" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList31" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox31" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox2" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList2" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList32" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox32" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox3" runat="server" Visible="False"
                                Width="49px"></asp:TextBox><asp:DropDownList ID="DropDownList3" runat="server"
                                    Visible="False" Width="100px">
                                    <asp:ListItem>Senin</asp:ListItem>
                                    <asp:ListItem>Selasa</asp:ListItem>
                                    <asp:ListItem>Rabu</asp:ListItem>
                                    <asp:ListItem>Kamis</asp:ListItem>
                                    <asp:ListItem>Jumat</asp:ListItem>
                                    <asp:ListItem>Sabtu</asp:ListItem>
                                </asp:DropDownList><asp:DropDownList ID="DropDownList33" runat="server" Visible="False" Width="100px">
                                </asp:DropDownList><asp:TextBox ID="TextBox33" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox4" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList4" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList34" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox34" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox5" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList5" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList35" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox35" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox6" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList6" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList36" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox36" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox7" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList7" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList37" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox37" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox8" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList8" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList38" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox38" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox9" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList9" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList39" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox39" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox10" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList10" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList40" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox40" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox11" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList11" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList41" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox41" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox12" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList12" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList42" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox42" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox13" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList13" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList43" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox43" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox14" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList14" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList44" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox44" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox15" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList15" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList45" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox45" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox16" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList16" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList46" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox46" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox17" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList17" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList47" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox47" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox18" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList18" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList48" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox48" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox19" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList19" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList49" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox49" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox20" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList20" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList50" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox50" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox21" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList21" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList51" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox51" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox22" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList22" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList52" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox52" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox23" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList23" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList53" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox53" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox24" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList24" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList54" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox54" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox25" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList25" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList55" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox55" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox26" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList26" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList56" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox56" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox27" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList27" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList57" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox57" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox28" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList28" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList58" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox58" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox29" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList29" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList59" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox59" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:TextBox ID="TextBox30" runat="server" Visible="False" Width="49px"></asp:TextBox><asp:DropDownList
                                ID="DropDownList30" runat="server" Visible="False" Width="100px">
                                <asp:ListItem>Senin</asp:ListItem>
                                <asp:ListItem>Selasa</asp:ListItem>
                                <asp:ListItem>Rabu</asp:ListItem>
                                <asp:ListItem>Kamis</asp:ListItem>
                                <asp:ListItem>Jumat</asp:ListItem>
                                <asp:ListItem>Sabtu</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="DropDownList60" runat="server" Visible="False" Width="100px">
                            </asp:DropDownList><asp:TextBox ID="TextBox60" runat="server" Visible="False" Width="49px"></asp:TextBox></div></div>
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


