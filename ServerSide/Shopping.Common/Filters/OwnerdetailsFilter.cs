using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Filters
{
    public class OwnerdetailsFilter
    {
        public long? UserId { get; set; }
        public string Username { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifyOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
