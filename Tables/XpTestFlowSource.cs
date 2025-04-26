using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class XpTestFlowSource
{
    public int Sn { get; set; }

    public string Id { get; set; } = null!;

    public string InputJson { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateTime Created { get; set; }

    public byte FlowLevel { get; set; }

    public string FlowStatus { get; set; } = null!;
}
