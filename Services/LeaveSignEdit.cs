using Base.Models;
using Base.Services;

namespace HrAdm.Services
{
    public class LeaveSignEdit : XpEdit
    {
        public LeaveSignEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            var locale = _Xp.GetLocale0();
            return new EditDto
            {
                ReadSql = $@"
select
    SignId=s.Id,
    LeaveId=l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name_{locale},
    UserName=u.Name,
    AgentName=u2.Name
from dbo.XpFlowSign s
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel and s.SignStatus='0'
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.Id='{{0}}'
",
            };
        }

    } //class
}
