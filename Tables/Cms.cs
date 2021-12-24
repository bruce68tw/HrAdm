using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class Cms
    {
        public string Id { get; set; }
        public string CmsType { get; set; }
        public string DataType { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
        public string Note { get; set; }
        public string FileName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Reviser { get; set; }
        public DateTime? Revised { get; set; }
    }
}
