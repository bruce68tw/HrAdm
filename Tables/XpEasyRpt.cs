using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class XpEasyRpt
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string TplFile { get; set; } = null!;

    public string ToEmails { get; set; } = null!;

    public string Sql { get; set; } = null!;

    public bool Status { get; set; }
}
