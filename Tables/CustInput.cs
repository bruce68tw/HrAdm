using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class CustInput
    {
        public string Id { get; set; }
        public string FldText { get; set; }
        public int FldNum { get; set; }
        public decimal FldNum2 { get; set; }
        public byte FldCheck { get; set; }
        public byte FldRadio { get; set; }
        public string FldSelect { get; set; }
        public DateTime FldDate { get; set; }
        public DateTime FldDatetime { get; set; }
        public string FldFile { get; set; }
        public string FldColor { get; set; }
        public string FldTextarea { get; set; }
        public string FldHtml { get; set; }
    }
}
