using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class UserSkill
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SkillName { get; set; }
        public string SkillDesc { get; set; }
        public int Sort { get; set; }
    }
}
