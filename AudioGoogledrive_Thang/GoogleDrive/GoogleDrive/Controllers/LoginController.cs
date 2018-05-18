using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleDrive.EF;
using GoogleDrive.Common;
using GoogleDrive.Models;
namespace GoogleDrive.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult DangNhap()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(LoginModel user)
        {
            var dao = new UserDao();
            var result = dao.Login(user.username, user.password);
            if (result)
            {
                var model = dao.GetByID(user.username);
                var userSession = new UserLogin();
                userSession.username = model.Username;
                userSession.ID = model.ID;
                Session.Add(CommonConstants.User_Session, userSession);
                return RedirectToAction("Index", "Home");
            }
            else
            {

            }

            return View("Index");
        }

        public ActionResult DangKy()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register(LoginModel user)
        {
            var dao = new UserDao();

            var result = dao.Insert(user.username, user.password);
            if (result > 0)
            {
                var model = dao.GetByID(user.username);
                var userSession = new UserLogin();
                userSession.username = model.Username;
                userSession.ID = model.ID;
                Session.Add(CommonConstants.User_Session, userSession);
                return RedirectToAction("Index", "Home");
            }
            else
            {

            }

            return View("Index");
        }
    }
}