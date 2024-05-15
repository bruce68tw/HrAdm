using System;
using System.Collections.Generic;

namespace HrAdm.Tables
{
    public partial class UserLang
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string LangName { get; set; } = null!;
        public string ListenLevel { get; set; } = null!;
        public string SpeakLevel { get; set; } = null!;
        public string ReadLevel { get; set; } = null!;
        public string WriteLevel { get; set; } = null!;
        public int Sort { get; set; }
    }
}
