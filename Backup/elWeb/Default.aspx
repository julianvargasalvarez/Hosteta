<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function() {


            $("#elLink").click(function() {
                alert("hola mundo");
            });

        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    This is running from inside
    <a id="elLink" href="#">Haga lick</a>
    </div>
    </form>
</body>
</html>
