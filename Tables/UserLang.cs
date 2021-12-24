using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class UserLang
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string LangName { get; set; }
        public string ListenLevel { get; set; }
        public string SpeakLevel { get; set; }
        public string ReadLevel { get; set; }
        public string WriteLevel { get; set; }
        public int Sort { get; set; }
    }
}
