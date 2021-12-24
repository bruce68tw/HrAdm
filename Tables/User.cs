using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public string DeptId { get; set; }
        public string PhotoFile { get; set; }
        public bool Status { get; set; }
    }
}
