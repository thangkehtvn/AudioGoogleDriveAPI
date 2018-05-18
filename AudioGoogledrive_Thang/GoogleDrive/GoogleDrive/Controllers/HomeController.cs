using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleDrive.Models;
using GoogleDrive.Common;
using System.Web;
using GoogleDrive.EF;
using GoogleDrive.Common;
namespace GoogleDrive.Controllers
{
    public class HomeController :BaseController
    {
        private WaveSteg file;
        private StagnoHelper sh;
        private string message;
        private bool HIDE_ERROR;
        public ActionResult Index()
        {
            var dao = new UserDao();
            var listBh = dao.ListBaiHat();
            var sess = (UserLogin)Session[CommonConstants.User_Session];
            if (sess != null)
            {
                var myMusic = dao.GetMyMusic(sess.username);
                ViewBag.MyMusic = myMusic;
            } else
            {
                ViewBag.MyMusic = "";
            }
            ViewBag.Title = "Home Page";
            ViewBag.ses = (UserLogin)Session[CommonConstants.User_Session];
            return View(listBh);
            //return View(GoogleDriveFilesRepository.Index());
        }
        public ActionResult Buy(int id)
        {
            var ses = (UserLogin)Session[CommonConstants.User_Session];
            new UserDao().Buy(ses.username,id);
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.User_Session] = null;

            return View("Index");
        }








        [HttpGet]
        public ActionResult GetGoogleDriveFiles()
        {
            return View(GoogleDriveFilesRepository.GetDriveFiles());
        }

        [HttpPost]
        public ActionResult DeleteFile(GoogleDriveFiles file)
        {
            GoogleDriveFilesRepository.DeleteFile(file);
            return RedirectToAction("GetGoogleDriveFiles");
        }

        [HttpPost]
        public ActionResult UploadFile(String tenbaihat, String tentacgia, HttpPostedFileBase file)
        {

            
            string signature = GoogleDriveFilesRepository.FileUpload(tenbaihat, tentacgia, file);
            ViewBag.Message = signature;
            return View();
        }
        public ActionResult Upload()
        {
            ViewBag.Message = "";
            ViewBag.ses = (UserLogin)Session[CommonConstants.User_Session];
            return View();
        }

        public void DownloadFile(string id)
        {
            string FilePath = GoogleDriveFilesRepository.DownloadGoogleFile(id);
            file = new WaveSteg(new FileStream(FilePath, FileMode.Open, FileAccess.Read));
            sh = new StagnoHelper(file);
             
            var sess = (UserLogin)Session[CommonConstants.User_Session];
            message = sess.username;
            sh.HideMessage(message);
            file.WriteFile(FilePath);


            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
            Response.WriteFile(System.Web.HttpContext.Current.Server.MapPath("~/GoogleDriveFiles/" + Path.GetFileName(FilePath)));
            Response.End();
            Response.Flush();
        }

        
        [HttpPost]
        public ActionResult CreateFolder(String FolderName)
        {
            GoogleDriveFilesRepository.CreateFolder(FolderName);
            return RedirectToAction("GetGoogleDriveFiles");
        }

        [HttpPost]
        public ActionResult FileUploadInFolder(GoogleDriveFiles FolderId, HttpPostedFileBase file)
        {
            GoogleDriveFilesRepository.FileUploadInFolder(FolderId.Id, file);
            return RedirectToAction("GetGoogleDriveFiles");
        }


        [HttpGet]
        public ActionResult GetContainsInFolder(string folderId)
        {
            return View(GoogleDriveFilesRepository.GetContainsInFolder(folderId));
        }

        [ChildActionOnly]
        public ActionResult Player(string id)
        {
            
            ViewBag.url = "https://drive.google.com/uc?export=download&id=" + id;
            return View();
        }



        public ActionResult NgheNhac(string id)
        {
            ViewBag.url = "https://docs.google.com/uc?export=download&id=" + id;
            ViewBag.ses = (UserLogin)Session[CommonConstants.User_Session];
            return View();

          
        }

       

    }
}