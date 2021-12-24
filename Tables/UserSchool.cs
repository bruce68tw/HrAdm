using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class UserSchool
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolDept { get; set; }
        public string SchoolType { get; set; }
        public string StartEnd { get; set; }
        public bool Graduated { get; set; }
    }
}
