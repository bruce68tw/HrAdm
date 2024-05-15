using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class UserJob
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string JobName { get; set; } = null!;
        public string? JobType { get; set; }
        public string? JobPlace { get; set; }
        public string? StartEnd { get; set; }
        public string? CorpName { get; set; }
        public int CorpUsers { get; set; }
        public bool IsManaged { get; set; }
        public string? JobDesc { get; set; }
    }
}
