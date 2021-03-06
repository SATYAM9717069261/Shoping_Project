using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Models
{
    public partial class Ownerdetails
    {
        public Ownerdetails()
        {
            Productdetails = new HashSet<Productdetails>();
            GoodRecipt = new HashSet<GoodRecipt>();
        }
        [Key]
        public long? UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifyOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Productdetails> Productdetails { get; set; }
        public ICollection<GoodRecipt> GoodRecipt { get; set; }
    }
}
