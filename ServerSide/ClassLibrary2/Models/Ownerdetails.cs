using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Models
{
    public partial class Ownerdetails
    {
        private static bool active;
        private static bool delete;
        private static DateTime currentdatatime;
        public long? UserId { get;}
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedOn { get { return currentdatatime; } set { currentdatatime = DateTime.Now; } }
        public System.DateTime ModifyOn { get { return currentdatatime; } set { currentdatatime = DateTime.Now; } }
        public bool IsActive { get { return active; } set { active = true; } }
        public bool IsDelete { get { return delete; } set { delete = value; } }
    }
}
