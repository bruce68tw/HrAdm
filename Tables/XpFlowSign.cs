using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpFlowSign
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string FlowId { get; set; } = null!;
        public string SourceId { get; set; } = null!;
        public string NodeName { get; set; } = null!;
        public short FlowLevel { get; set; }
        public short TotalLevel { get; set; }
        public string SignerId { get; set; } = null!;
        public string SignerName { get; set; } = null!;
        public string SignStatus { get; set; } = null!;
        public DateTime? SignTime { get; set; }
        public string? Note { get; set; }
    }
}
