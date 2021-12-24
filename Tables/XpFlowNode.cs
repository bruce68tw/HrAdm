using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpFlowNode
    {
        public string Id { get; set; }
        public string FlowId { get; set; }
        public string Name { get; set; }
        public string NodeType { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public string SignerType { get; set; }
        public string SignerValue { get; set; }
        public string PassType { get; set; }
        public short? PassNum { get; set; }
    }
}
