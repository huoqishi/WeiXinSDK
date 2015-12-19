using ISC.WeiXin.PN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult CusMenu()
        {
            return View();
        }
        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMenu()
        {
            ///记录调用次数
            var logPath = Server.MapPath(string.Format("~/App_Data/MP/{0}/", DateTime.Now.ToString("yyyy-MM-dd")));
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            using (StreamWriter sw = new StreamWriter(logPath + "getmenu.txt", true, Encoding.UTF8))
            {
                sw.WriteLine("调用一次");
            }
            return Content(CustomMenu.GetMenu());
        }
        public ActionResult GetMenu2()
        {
            return Content("无效接口");
        }
        [HttpPost]
        public ActionResult SaveMenu(string menu)
        {
            ///记录调用次数
            var logPath = Server.MapPath(string.Format("~/App_Data/MP/{0}/", DateTime.Now.ToString("yyyy-MM-dd")));
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            using (StreamWriter sw=new StreamWriter(logPath+"savemenu.txt",true,Encoding.UTF8))
            {
                sw.WriteLine("调用一次");
            }
            return Content(CustomMenu.CreatMenu(menu));
        }

        public ActionResult Test2()
        {
            return View();
        }
    }
}
