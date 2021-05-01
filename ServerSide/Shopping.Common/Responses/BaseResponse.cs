using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class BaseResponse
    {
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }

        public bool? Sucess { get; set; }// represent sucessfully store data in database
    }
}
