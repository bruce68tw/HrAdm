using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class XpFlowLine
{
    public string Id { get; set; } = null!;

    public string FlowId { get; set; } = null!;

    public string FromNodeId { get; set; } = null!;

    public string ToNodeId { get; set; } = null!;

    public string? FromType { get; set; }

    public string? CondStr { get; set; }

    public short Sort { get; set; }
}
