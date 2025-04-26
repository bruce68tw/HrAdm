using System;
using System.Collections.Generic;

namespace HrAdm.Tables;

public partial class Leave
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string AgentId { get; set; } = null!;

    public string LeaveType { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Hours { get; set; }

    public byte FlowLevel { get; set; }

    public string FlowStatus { get; set; } = null!;

    public string? FileName { get; set; }

    public bool Status { get; set; }

    public string Creator { get; set; } = null!;

    public DateTime Created { get; set; }

    public string? Reviser { get; set; }

    public DateTime? Revised { get; set; }
}
