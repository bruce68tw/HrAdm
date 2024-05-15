using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class XpUserRole
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}
