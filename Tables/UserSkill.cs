using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class UserSkill
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string SkillName { get; set; } = null!;

    public string? SkillDesc { get; set; }

    public int Sort { get; set; }
}
