using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class UserLicense
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string LicenseName { get; set; } = null!;

    public string? StartEnd { get; set; }

    public string? FileName { get; set; }
}
