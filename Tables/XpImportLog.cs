using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpImportLog
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public int OkCount { get; set; }
        public int FailCount { get; set; }
        public int TotalCount { get; set; }
        public string CreatorName { get; set; }
        public DateTime Created { get; set; }
    }
}
