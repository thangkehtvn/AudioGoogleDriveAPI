using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleDrive.Common
{
    [Serializable]
    public class UserLogin
    {
        public int ID { set; get; }
        public String username { set; get; }
    }
}