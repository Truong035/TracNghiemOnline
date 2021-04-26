<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="bai2_thuchanh.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 >login to website</h1>
            <div><label>student name :&nbsp; </label><asp:TextBox ID="studentname" runat="server"></asp:TextBox></div><br />
            <div><label>password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</label><asp:TextBox ID="pass" runat="server"></asp:TextBox></div><br />
            <asp:Label ID="thongbao" runat="server" Text=""></asp:Label><br /><br />
            <asp:Button ID="Button1" runat="server" Text="login" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
