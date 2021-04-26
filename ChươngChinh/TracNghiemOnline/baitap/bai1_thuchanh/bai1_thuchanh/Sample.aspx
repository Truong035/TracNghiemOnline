<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="bai1_thuchanh.Sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Enter your name :
            <asp:TextBox ID="txtYourName" runat="server" Height="22px" Width="208px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="Display" />
        </p>
        <p>
            Hello :
            <asp:Label ID="lbHello" runat="server"></asp:Label>
        </p>
        <p>
            Page is postback : <asp:Label ID="lbPageIsPostBack" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
