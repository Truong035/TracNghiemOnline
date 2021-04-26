using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1_thuchanh
{
    public partial class Sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbPageIsPostBack.Text = Page.IsPostBack.ToString();

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            lbPageIsPostBack.Text = Page.IsPostBack.ToString();
            if (txtYourName.Text != null)
            {
                lbHello.Text = txtYourName.Text;
            }
           

        }
    }
}