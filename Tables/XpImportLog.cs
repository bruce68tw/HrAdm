using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class XpImportLog
{
    public string Id { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public short OkCount { get; set; }

    public short FailCount { get; set; }

    public short TotalCount { get; set; }

    public string CreatorName { get; set; } = null!;

    public DateTime Created { get; set; }
}
