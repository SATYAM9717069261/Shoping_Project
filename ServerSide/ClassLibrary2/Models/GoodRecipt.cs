using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.DataLayer.Models
{
    public class GoodRecipt
    {
        [Key]
        public long? Grnumber { get; set; }
        public long? OwnerdetailUserId { get; set; }
        public long? ProductdetailProductId { get; set; }
        public string CustomerName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
        public string BillNumber { get; set; }
        public Ownerdetails Ownerdetail { get; set; }
    }
}
