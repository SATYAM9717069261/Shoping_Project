using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Models
{
    public class Productdetails
    {
        [Key]
        public long ProductId { get; set; }
        public long OwnerdetailUserId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public long? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifyOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public long? Rating { get; set; }
        public Ownerdetails Ownerdetail { get; set; }

    }
}
