using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpFlowNode
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string FlowId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NodeType { get; set; } = null!;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public string? SignerType { get; set; }
        public string? SignerValue { get; set; }
        public string PassType { get; set; } = null!;
        public short? PassNum { get; set; }
    }
}
