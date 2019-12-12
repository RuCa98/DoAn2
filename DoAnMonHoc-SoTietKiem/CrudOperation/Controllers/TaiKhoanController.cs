using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class TaiKhoanController : Controller
    {
        //Quản lý tài khoản
        public ActionResult Index()
        {
            return View();
        }
    }
}