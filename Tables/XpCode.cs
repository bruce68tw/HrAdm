using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class XpCode
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Name_zhTW { get; set; }
        public string Name_zhCN { get; set; }
        public string Name_enUS { get; set; }
        public int Sort { get; set; }
        public string Ext { get; set; }
        public string Note { get; set; }
    }
}
