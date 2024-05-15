using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class Dept
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MgrId { get; set; } = null!;
    }
}
