using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpFlowTest
    {
        public string Id { get; set; }
        public string InputJson { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public byte FlowLevel { get; set; }
        public string FlowStatus { get; set; }
    }
}
