using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpTranLog
    {
        public int Sn { get; set; }
        public string RowId { get; set; }
        public string TableName { get; set; }
        public string ColName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Act { get; set; }
        public DateTime Created { get; set; }
    }
}
