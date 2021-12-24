using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpEasyRpt
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TplFile { get; set; }
        public string ToEmails { get; set; }
        public string Sql { get; set; }
        public bool Status { get; set; }
    }
}
