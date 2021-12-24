using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpFlowLine
    {
        public string Id { get; set; }
        public string FlowId { get; set; }
        public string StartNode { get; set; }
        public string EndNode { get; set; }
        public string CondStr { get; set; }
        public short Sort { get; set; }
    }
}
