using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpFlowLine
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string FlowId { get; set; } = null!;
        public string StartNode { get; set; } = null!;
        public string EndNode { get; set; } = null!;
        public string? CondStr { get; set; }
        public short Sort { get; set; }
    }
}
