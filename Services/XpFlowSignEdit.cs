using Base.Models;
using Base.Services;
using BaseApi.Services;

namespace HrAdm.Services
{
    public class XpFlowSignEdit : BaseEditSvc
    {
        private string _flowCode;   //XpFlow.Code
        public XpFlowSignEdit(string ctrl, string flowCode) : base(ctrl) 
        {
            _flowCode = flowCode;
        }

        override public EditDto GetDto()
        {
            string sql = "";
            var locale = _Locale.GetLocale();
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
join dbo.XpUser u on l.UserId=u.Id
join dbo.XpUser u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where l.Id=@Id
";
            }

            return new EditDto() { ReadSql = sql };
        }

    } //class
}
