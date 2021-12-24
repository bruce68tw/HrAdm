using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class UserLicense
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string LicenseName { get; set; }
        public string StartEnd { get; set; }
        public string FileName { get; set; }
    }
}
