using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpTranLog
    {
        public int Sn { get; set; }
        public string RowId { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public string? ColName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string Act { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
