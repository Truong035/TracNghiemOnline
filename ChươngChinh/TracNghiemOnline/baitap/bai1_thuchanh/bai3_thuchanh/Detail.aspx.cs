using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai3_thuchanh
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Text = Request.QueryString["id"];
            Label6.Text = Request.QueryString["name"];
            Label7.Text = Request.QueryString["diachi"];
            Label8.Text = Request.QueryString["sdt"];
            Label9.Text = Request.QueryString["des"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}