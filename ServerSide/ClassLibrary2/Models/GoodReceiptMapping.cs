using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.DataLayer.Models
{
    public class GoodReceiptMapping
    {
        [Key]
        public long? mappedid { get; set; }
        public string logo { get; set; }
        public string header { get; set; }
        public long? UserId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }

    }
}
