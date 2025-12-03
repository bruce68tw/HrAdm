using Base.Models;
using Base.Services;
using BaseApi.Services;

namespace HrAdm.Services
{
    public class LeaveSignEdit : BaseEditSvc
    {
        public LeaveSignEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            var locale = _Locale.GetLocaleNoDash();
            return new EditDto
            {
                ReadSql = $@"
select
    SignId=s.Id,
    LeaveId=l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name_{locale},
    UserName=u.Name,
    AgentName=u2.Name,
    {_Fun.FidUser}=u3.Id, {_Fun.FidDept}=u3.DeptId
from dbo.XpFlowSign s
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel
join dbo.XpUser u on l.UserId=u.Id
join dbo.XpUser u2 on l.AgentId=u2.Id
join dbo.XpUser u3 on s.SignerId=u3.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.Id=@Id
",
            };
        }

    } //class
}
