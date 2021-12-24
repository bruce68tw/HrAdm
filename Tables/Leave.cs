using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class Leave
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Hours { get; set; }
        public byte FlowLevel { get; set; }
        public string FlowStatus { get; set; }
        public string FileName { get; set; }
        public bool Status { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Reviser { get; set; }
        public DateTime? Revised { get; set; }
    }
}
