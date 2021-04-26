<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="information.aspx.cs" Inherits="bai4_thuchanh.information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .txtlabel{
            color:green;
            text-align:left;

        }
        .divleft{
            float:left;
            margin-right:10px;
            text-align:right;
            padding:10px
                
        }
        .divright{
            float:left;
        }
        .muc{
            clear:left;
            color:#E3DEDE;
            background-color:green;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server"><h1 style="text-align:center;color:aquamarine" > ĐĂNG KÝ THÔNG TIN VIỆT LÀM</h1>
       
        <div>
            <div class="divleft">
                <asp:Label ID="Label1" CssClass="txtlabel"  runat="server" Text="* Họ & tên:"></asp:Label><br />
                <asp:Label ID="Label2" CssClass="txtlabel"  runat="server" Text="*Ngày tháng năm sinh:"></asp:Label><br />
                <asp:Label ID="Label3"  CssClass="txtlabel" runat="server" Text="Giới tính:"></asp:Label><br />
                <asp:Label ID="Label4" CssClass="txtlabel"  runat="server" Text="Tình trạng hộn nhân:"></asp:Label><br />
            </div>
            <div class="divright">
                <asp:TextBox ID="Txtname" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="Txtdate" runat="server"></asp:TextBox><br />
                <asp:DropDownList ID="gioitinh" runat="server">
                    <asp:ListItem>nam</asp:ListItem>
                    <asp:ListItem>nu</asp:ListItem>
                </asp:DropDownList><br />
                <asp:DropDownList ID="trhn" runat="server">
                   <asp:ListItem>doc than</asp:ListItem>
                    <asp:ListItem>da ket hon</asp:ListItem>
                </asp:DropDownList>
               
            </div>
        &nbsp;&nbsp;&nbsp;
        </div>
        <h3 class="muc">Thông tin liên lạc</h3>

        <div>
            <div class="divleft">
                <asp:Label ID="Label5" CssClass="txtlabel"  runat="server" Text="*Địa chỉ"></asp:Label><br />
                <asp:Label ID="Label6" CssClass="txtlabel"  runat="server" Text="* Tỉnh/Thành phố"></asp:Label><br />
                <asp:Label ID="Label7"  CssClass="txtlabel" runat="server" Text="Số điện thoại"></asp:Label><br />
                <asp:Label ID="Label8" CssClass="txtlabel"  runat="server" Text="Số điện thoại di động"></asp:Label><br />
                <asp:Label ID="Label21" CssClass="txtlabel"  runat="server" Text="Email"></asp:Label><br />
            </div>
            <div class="divright">
                <asp:TextBox ID="diachi" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="tinhtp" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="sdt" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="sdtdd" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="email" runat="server"></asp:TextBox><br />
               
            </div>

        </div>

        <h3 class="muc">Trình độ học vấn</h3>

        <div>
            <div class="divleft">
                <asp:Label ID="Label9" CssClass="txtlabel"  runat="server" Text="*Trình độ học vấn"></asp:Label><br />
                <asp:Label ID="Label10" CssClass="txtlabel"  runat="server" Text="*Thông tin về học vấn:	"></asp:Label><br />
                <asp:Label ID="Label11"  CssClass="txtlabel" runat="server" Text="Ngoại ngữ:	"></asp:Label><br />
                <asp:Label ID="Label12" CssClass="txtlabel"  runat="server" Text="Kỹ năng:"></asp:Label><br />
            </div>
            <div class="divright">
                <asp:DropDownList ID="trthv" runat="server">
                    <asp:ListItem>Chọn</asp:ListItem>
                    <asp:ListItem>Không</asp:ListItem>
                    <asp:ListItem>Mẫu giáo</asp:ListItem>
                    <asp:ListItem>Tiểu học</asp:ListItem>
                    <asp:ListItem>Trung học cơ sở</asp:ListItem>
                    <asp:ListItem>Trung học phổ thông</asp:ListItem>
                    <asp:ListItem>Đại học</asp:ListItem>
                    <asp:ListItem>Khác</asp:ListItem>
                </asp:DropDownList><br />
                
                <asp:TextBox ID="tthv" runat="server" Height="100px" Width="500px" TextMode="MultiLine"></asp:TextBox><br />
                <asp:TextBox ID="ngoaingu" runat="server" Height="100px" Width="500px" TextMode="MultiLine"></asp:TextBox><br />
                <asp:TextBox ID="kynang" runat="server" Height="100px" Width="500px" TextMode="MultiLine"></asp:TextBox><br />

               
            </div>

        </div>

        <h3 class="muc">Kinh nghiệm làm việc</h3>

        <div>
            <div class="divleft">
                <asp:Label ID="Label13" CssClass="txtlabel"  runat="server" Text="Số năm kinh nghiệm"></asp:Label><br />
                <asp:Label ID="Label14" CssClass="txtlabel"  runat="server" Text="Kinh nghiệm làm việc	"></asp:Label><br />
                
            </div>
            <div class="divright">
                <asp:TextBox ID="sonamkn" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="kinhnghiemlv" runat="server" Height="100px" Width="500px" TextMode="MultiLine"></asp:TextBox><br />
               
            </div>

        </div>

       <h3 class="muc">Mong muốn bản thân</h3>

        <div>
            <div class="divleft">
                <asp:Label ID="Label17" CssClass="txtlabel"  runat="server" Text="Việc làm mong muốn:"></asp:Label><br />
                <asp:Label ID="Label18" CssClass="txtlabel"  runat="server" Text="*mức lương thỏa thuận	"></asp:Label><br />
            </div>
            <div class="divright">
                <asp:TextBox ID="vieclammm" runat="server" Height="100px" Width="500px" TextMode="MultiLine"></asp:TextBox><br />
                <asp:TextBox ID="mucluongtt" runat="server"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" Text="Gửi hồ sơ" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="xóa form" OnClick="Button2_Click" style="height: 29px" />
            </div>

        </div>
    </form>
</body>
</html>
