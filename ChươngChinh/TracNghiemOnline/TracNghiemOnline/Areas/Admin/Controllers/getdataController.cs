using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Modell;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class getdataController : Controller
    {
        // GET: Admin/getdata
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getdata()
        {
            return View();
        }
        public  bool ktlink(string s)
        {

            FileStream fs = new FileStream(Server.MapPath("~/Content/excel/textfile.txt"), FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs))
            {
                string a = sr.ReadToEnd();
                Console.WriteLine(a);
                if (a.Contains(s))
                {
                    return false;
                }
                else
                {
                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Content/excel/textfile.txt"), append: true))
                    {
                        sw.WriteLine(s);
                        sw.Close();


                    }
                    return true;
                }
            }

            return false;
        }

        public  List<string> getfiletkb()
        {
            List<string> trangtt = new List<string>();
            HtmlWeb htmlWeb = new HtmlWeb();
            /* {
                 AutoDetectEncoding = false,
                 OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
             };*/
            for (int i = 1; i <= 45; i++)
            {
                HtmlDocument document = htmlWeb.Load("https://utc2.edu.vn/thong-bao/p=" + i);
                var threadItems = document.DocumentNode.SelectNodes("//div[@class='mucdichvu']/h3").ToList();

                var items = new List<object>();
                foreach (var item in threadItems)
                {
                    //Extract các giá trị từ các tag con của tag li
                    var linkNode = item.SelectSingleNode(".//a");
                    var link = linkNode.Attributes["href"].Value;

                    if (link.Contains("chinh-thuc-thoi-khoa-bieu") && ktlink(link))
                    {

                        HtmlDocument document1 = htmlWeb.Load("https://utc2.edu.vn/" + link);
                        var threadItems1 = document1.DocumentNode.SelectNodes("//div[@id='noidungtrong']/p").ToList();
                        var items1 = new List<object>();
                        foreach (var item1 in threadItems1)
                        {
                            //Extract các giá trị từ các tag con của tag li
                            var linkNode1 = item1.SelectSingleNode(".//a");
                            if (linkNode1 != null)
                            {
                                var link1 = linkNode1.Attributes["href"].Value;
                                if (link1.Contains("https://utc2.edu.vn"))
                                {

                                    trangtt.Add(Server.MapPath("~/Content/excel/") + link + ".xls");
                                    WebClient webClient1 = new WebClient();
                                    webClient1.DownloadFile(link1, Server.MapPath("~/Content/excel/") + link + ".xls");
                                }
                                else
                                {
                                    trangtt.Add(Server.MapPath("~/Content/excel/") + link + ".xls");
                                    WebClient webClient = new WebClient();
                                    webClient.DownloadFile("https://utc2.edu.vn" + link1, Server.MapPath("~/Content/excel/") + link + ".xls");
                                }


                                break;
                            }

                        }
                    }
                }
            }

            return trangtt;
        }
        public ActionResult getclass()
        {

           /* List<string> linkfile = getfiletkb();
            foreach (var item in linkfile)
            {
                Workbook workbook = new Workbook();

                workbook.LoadFromFile("" + item);

                Worksheet sheet = workbook.Worksheets[0];

                for (int k = 9; k < 10000; k++)
                {
                    if (sheet.Range["D" + k].Text != null&& sheet.Range["B" + k].Text != null&& sheet.Range["D" + k].Text != null)
                    {
                        LopHocPhan lhp = new LopHocPhan();
                        lhp.TenLop = sheet.Range["D" + k].Text;
                        lhp.SiSo = sheet.Range["D" + k].Text;
                        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                        db.LopHocPhans.Add(lhp);
                        db.SaveChanges();

                    }


                   
                }
            }*/


            return Content("lay  thanh cong");

        }
        public ActionResult getstudent()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            // Chạy ngầm không pop up trình duyệt ra ngoài 
            options.AddArgument("headless");
            IWebDriver webDriver = new ChromeDriver(Server.MapPath("~/Content/chromdriver"),options);
            webDriver.Url = "http://xemdiem.utc2.edu.vn/xemdiem.aspx";
            
            var radiobutton = webDriver.FindElement(By.XPath("//*[@id='sfsdfdslf']/table/tbody/tr[1]/td[2]/input[2]"));
            radiobutton.Click();

            var khoa = webDriver.FindElement(By.Name("DropDownList2"));
            var select = new SelectElement(khoa);
            select.SelectByValue("558");
            var lop = webDriver.FindElement(By.Name("DropDownList3"));
            var selectlop = new SelectElement(lop);
            selectlop.SelectByValue("5441");
            var button = webDriver.FindElement(By.XPath("//*[@id='Tim']"));
            button.Click();



            var table = webDriver.FindElement(By.XPath("//*[@id='listsinhvien']/div/table/tbody"));
            var rows_table = table.FindElements(By.TagName("tr"));
            int rows_count = rows_table.Count;
            int z = 1;
            foreach (var item in rows_table)
            {
                if (z == 1 || z == rows_count)
                {

                }
                else
                {
                    var tablesv = item.FindElements(By.TagName("td"));
                    TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                   
                        SinhVien sv = new SinhVien();
                        sv.MaSV = tablesv[2].Text;
                        sv.Ten = tablesv[3].Text;
                    
                    sv.NgaySinh = DateTime.ParseExact(tablesv[4].Text,"d/M/yyyy", CultureInfo.InvariantCulture);
                    sv.DiaChi = tablesv[5].Text;
                    if (db.SinhViens.Where(x => x.MaSV.Equals(sv.MaSV)).ToList().Count <= 0)
                    {
                        db.SinhViens.Add(sv);
                        db.SaveChanges();
                    }
                    
                   
                    /*  Console.OutputEncoding = Encoding.Unicode; Console.InputEncoding = Encoding.Unicode;
                      Console.WriteLine("heloooooooooooo" + tablesv[3].Text);*/


                }
                z++;
            }




            for (int slpage = 1; slpage <= 2; slpage++)
            {
                var page = webDriver.FindElement(By.XPath("//*[@id='listsinhvien']/table[1]/tbody/tr/td/font/font/b/a[" + slpage + "]"));
                page.Click();

                var table1 = webDriver.FindElement(By.XPath("//*[@id='listsinhvien']/div/table/tbody"));
                var rows_table1 = table1.FindElements(By.TagName("tr"));
                int rows_count1 = rows_table1.Count;
                int z1 = 1;
                foreach (var item in rows_table1)
                {
                    if (z1 == 1 || z1 == rows_count1)
                    {

                    }
                    else
                    {
                        var tablesv = item.FindElements(By.TagName("td"));
                        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                        
                        SinhVien sv = new SinhVien();
                        sv.MaSV = tablesv[2].Text;
                        sv.Ten = tablesv[3].Text;
                        sv.NgaySinh = DateTime.ParseExact(tablesv[4].Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                        sv.DiaChi = tablesv[5].Text;
                        if (db.SinhViens.Where(x => x.MaSV.Equals(sv.MaSV)).ToList().Count <= 0)
                        {
                            db.SinhViens.Add(sv);
                            db.SaveChanges();
                        }

                        /*
                                                Console.OutputEncoding = Encoding.Unicode; Console.InputEncoding = Encoding.Unicode;
                                                Console.WriteLine("heloooooooooooo" + tablesv[3].Text);*/


                    }
                    z1++;
                }
            }
            return Content("lay  thanh cong");
        }

    }
}