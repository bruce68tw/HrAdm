using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpFlowSign
    {
        public string Id { get; set; }
        public string FlowId { get; set; }
        public string SourceId { get; set; }
        public string NodeName { get; set; }
        public short FlowLevel { get; set; }
        public short TotalLevel { get; set; }
        public string SignerId { get; set; }
        public string SignerName { get; set; }
        public string SignStatus { get; set; }
        public DateTime? SignTime { get; set; }
        public string Note { get; set; }
    }
}
