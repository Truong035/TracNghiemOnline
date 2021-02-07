using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using TracNghiemOnline.Model;
using EXCELL = Microsoft.Office.Interop.Excel;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class CauHoiController : Controller
    {
        // GET: Admin/CauHoi
        static List<CauHoi> cauHois=new List<CauHoi>();
        public ActionResult Index(string id)
        {
           
            return View();
        }

        public ActionResult CreateCauHoi(string id)
        {
     
            return View(cauHois);
        }
        public ActionResult LoalFile(string id)
        {
          
            return View(cauHois);
        }

        public ActionResult XuLyFile(HttpPostedFileBase file)
        {
            try
            {
                string path = Server.MapPath("~/Content/" + file.FileName);
                file.SaveAs(path);
                string LINK1 = "Sheet1";
                string conec = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""", path);
            
                string query = string.Format("Select * from  [{0}$]", LINK1);
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(query, conec);
                DataTable dataSet = new DataTable();
                oleDbDataAdapter.Fill(dataSet);
                cauHois = new List<CauHoi>();
                MessageBox.Show(""+dataSet.Rows.Count);
                foreach (DataRow item in dataSet.Rows)
                {
                    CauHoi cauHoi = new CauHoi();
                    cauHoi.NoiDubg1 = item["CauHoi"].ToString();
                    MessageBox.Show("" + item["HinhAnh"].ToString());
                    cauHoi.HinhAnh1= item["HinhAnh"].ToString();
                    cauHoi.CauHois = new List<DapAn>();
                    DapAn dapAn = new DapAn();
                    dapAn.NoiDung1 = item["A"].ToString();
                
                    if (item["CauTraLoi"].ToString().Equals("A"))
                    {
                        dapAn.TrangThai1 = true;
                    }
                    else { dapAn.TrangThai1 = false; }
                    cauHoi.CauHois.Add(dapAn);
                     dapAn = new DapAn();
                    dapAn.NoiDung1 = item["B"].ToString();

                    if (item["CauTraLoi"].ToString().Equals("B"))
                    {
                        dapAn.TrangThai1 = true;
                    }
                    else { dapAn.TrangThai1 = false; }
                    cauHoi.CauHois.Add(dapAn);
                     dapAn = new DapAn();
                    dapAn.NoiDung1 = item["C"].ToString();

                    if (item["CauTraLoi"].ToString().Equals("C"))
                    {
                        dapAn.TrangThai1 = true;
                    }
                    else { dapAn.TrangThai1 = false; }
                    cauHoi.CauHois.Add(dapAn);

                     dapAn = new DapAn();
                    dapAn.NoiDung1 = item["D"].ToString();

                    if (item["CauTraLoi"].ToString().Equals("D"))
                    {
                        dapAn.TrangThai1 = true;
                    }
                    else { dapAn.TrangThai1 = false; }
                    cauHoi.CauHois.Add(dapAn);

                    cauHois.Add(cauHoi);

                }
                return Content("True");


            }
            catch ( Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return Content("false");
        }
    }
}