using Base.Models;
using Base.Services;

namespace HrAdm.Services
{
    public class XpFlowSignEdit : XpEdit
    {
        private string _flowCode;   //XpFlow.Code
        public XpFlowSignEdit(string ctrl, string flowCode) : base(ctrl) 
        {
            _flowCode = flowCode;
        }

        override public EditDto GetDto()
        {
            string sql = "";
            var locale = _Xp.GetLocale0();
            if (_flowCode == "Leave")
            {
                sql = $@"
select
    l.Id,
    l.StartTime, l.EndTime, l.Hours, l.Created, l.FileName,
    LeaveName=c.Name_{locale},
    UserName=u.Name,
    AgentName=u2.Name
from dbo.Leave l
join dbo.[User] u on l.UserId=u.Id
join dbo.[User] u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where l.Id='{{0}}'
";
            }

            return new EditDto() { ReadSql = sql };
        }

    } //class
}
