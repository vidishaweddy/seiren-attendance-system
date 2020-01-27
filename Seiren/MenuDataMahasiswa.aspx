<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuDataMahasiswa.aspx.cs" Inherits="_Default" %>

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
	        width:350px;
	        height:188px;
	        background:transparent url("../images/newCoba.png") no-repeat;
	        float:left;
	        margin:1px;
        }
        #Browse{
	        width:350px;
	        height:188px;
	        background:transparent url("../images/browseCoba.png") no-repeat;
	        float:right;
	        margin:1px;
        }
        #Admin{
	        width:350px;
	        height:188px;
	        background:transparent url("../images/adminCoba.png") no-repeat center;
	        float:left;
	        margin:1px;
        }
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
	        
	        padding:50px 10px 50px 10px;
        {
</style>
        <script src="js/jquery-1.2.6.js" type="text/javascript"></script>
        <script type="text/javascript">
        
		$(document).ready(function(){
			$("#New").css({
				"opacity": "0.3"
			});
			$("#Admin").css({
				"opacity": "0.3"
			});
			$("#Browse").css({
				"opacity": "0.3"
			});
			$("#Data").css({
				"opacity": "0.3"
			});
			$("#Data").mouseover(function(){
				$("#Data").fadeTo("fast",0.9);
			});
			$("#Data").mouseout(function(){
				$("#Data").fadeTo("fast",0.3);
			});
			$("#Data").click(function(){
				parent.location.href="browse.aspx"
			});
			$("#Browse").mouseover(function(){
				$("#Browse").fadeTo("fast",0.9);
			});
			$("#Browse").mouseout(function(){
				$("#Browse").fadeTo("fast",0.3);
			});
			$("#Browse").click(function(){
				parent.location.href="browse.aspx"
			});
			$("#Admin").click(function(){
				parent.location.href="AdminMain.aspx"
			});
			$("#Admin").mouseover(function(){
				$("#Admin").fadeTo("fast",0.9);
			});
			$("#Admin").mouseout(function(){
				$("#Admin").fadeTo("fast",0.3);
			});
			$("#New").click(function(){
				parent.location.href="new.aspx"
			});
			$("#New").mouseover(function(){
				$("#New").fadeTo("fast",0.9);
			});
			$("#New").mouseout(function(){
				$("#New").fadeTo("fast",0.3);
			});
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
                            <!--  <div id="sticker">-->
                                
                            <!--  </div>-->
                            
                                
                                                              
                                <div id="New">
                                </div>
                                <div id="Admin">
                                </div>
                                <div id="Browse">
                                </div>
                                </div>
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

