using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpFlow
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Portrait { get; set; }
        public bool Status { get; set; }
    }
}
