using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpImportLog
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public short OkCount { get; set; }
        public short FailCount { get; set; }
        public short TotalCount { get; set; }
        public string CreatorName { get; set; }
        public DateTime Created { get; set; }
    }
}
