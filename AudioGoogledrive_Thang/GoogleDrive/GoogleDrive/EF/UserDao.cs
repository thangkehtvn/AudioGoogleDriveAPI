using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleDrive.EF
{
    public class UserDao
    {
        MusicModel db = null;
        public UserDao()
        {
            db = new MusicModel();
        }
        public int Insert(string user, string password)
        {
            if (db.Users.SingleOrDefault(x => x.Username == user)!=null)
                return 0;
            else
            {
                User entity = new User();
                entity.Username = user;
                entity.Password = password;
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            
        }
        public User GetByID(string username)
        {
            return db.Users.SingleOrDefault(x => x.Username.Equals(username) );
        }
        public bool Login(string user, string password)
        {
            var result = db.Users.Count(x => x.Username == user && x.Password == password);
            if (result > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }


        public int UploadMusic(string tenbaihat, string tentacgia, string id)
        {
            BaiHat bh = new BaiHat();
            bh.IdDrive = id;
            bh.Author = tentacgia;
            bh.TenBaiHat = tenbaihat;
            db.BaiHats.Add(bh);
            db.SaveChanges();
            return 1;
            
             
        }
        public List<BaiHat> ListBaiHat()
        {
            return db.BaiHats.ToList();
        }
        public List<SoHuu> GetMyMusic(string account)
        {
            return db.SoHuus.Where(x => x.TenUser == account).ToList();
        }

        public int Buy(string account, int id)
        {
            try
            {
                var bh = db.BaiHats.Find(id);

                SoHuu sh = new SoHuu();
                sh.TenUser = account;
                sh.Idbaihat = bh.IdDrive;
                db.SoHuus.Add(sh);
                db.SaveChanges();
                return sh.ID;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}