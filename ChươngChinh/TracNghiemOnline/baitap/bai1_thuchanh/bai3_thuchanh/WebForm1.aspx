<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="bai3_thuchanh.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <table class="auto-style1">
                <tr>
                    <td colspan ="2" style="text-align:center">
                        Employee Management<br /> System
                    </td>

                </tr>
                <tr>
                    <td class="auto-style2">Employee ID</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Employee Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Employee Address</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtAdd" runat="server" Height="25px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Phone Number</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addNum" runat="server" TextMode="Number" BorderStyle="Dotted"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Designation</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="162px">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Staff</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style3">
                        <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>


