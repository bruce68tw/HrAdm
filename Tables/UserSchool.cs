using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class UserSchool
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string SchoolName { get; set; } = null!;

    public string? SchoolDept { get; set; }

    public string? SchoolType { get; set; }

    public string? StartEnd { get; set; }

    public bool Graduated { get; set; }
}
