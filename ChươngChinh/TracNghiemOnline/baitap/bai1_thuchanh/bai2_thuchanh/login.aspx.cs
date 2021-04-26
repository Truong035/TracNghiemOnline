using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace bai2_thuchanh
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (studentname.Text != null && pass.Text != null&& studentname.Text == "DungTA" && pass.Text == "123456")
            {
                Response.Redirect("welcome.aspx?name="+ studentname.Text);
            }
            else if (studentname.Text == null && pass.Text == null)
            {

                thongbao.Text="tai khoan mat khau khong duoc de trong";
            }
            else if (studentname.Text != "DungTA" && pass.Text != "123456")
            {

                thongbao.Text = "tai khoan mat khau khong dung";
            }

        }
    }
}