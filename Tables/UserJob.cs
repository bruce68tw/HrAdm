using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class UserJob
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string JobName { get; set; }
        public string JobType { get; set; }
        public string JobPlace { get; set; }
        public string StartEnd { get; set; }
        public string CorpName { get; set; }
        public int CorpUsers { get; set; }
        public bool IsManaged { get; set; }
        public string JobDesc { get; set; }
    }
}
