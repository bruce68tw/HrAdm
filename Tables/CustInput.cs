using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class CustInput
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string? FldText { get; set; }
        public int? FldInt { get; set; }
        public double? FldDec { get; set; }
        public bool? FldCheck { get; set; }
        public byte? FldRadio { get; set; }
        public string? FldSelect { get; set; }
        public DateTime? FldDate { get; set; }
        public DateTime? FldDt { get; set; }
        public string? FldFile { get; set; }
        public string? FldColor { get; set; }
        public string? FldTextarea { get; set; }
        public string? FldHtml { get; set; }
    }
}
