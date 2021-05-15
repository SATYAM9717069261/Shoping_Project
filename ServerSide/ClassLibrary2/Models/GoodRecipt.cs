using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.DataLayer.Models
{
    public class GoodRecipt
    {
        public long? Grnumber { get; set; }
        public long? UserId { get; set; }
        public long ProductId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
    }
}
