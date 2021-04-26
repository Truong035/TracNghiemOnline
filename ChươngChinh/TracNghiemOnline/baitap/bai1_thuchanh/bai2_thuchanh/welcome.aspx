<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="bai2_thuchanh.welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #logout{
        margin-left:200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="welcome "></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <a href="login.aspx" id="logout">Logout</a>
        </div>
    </form>
</body>
</html>
