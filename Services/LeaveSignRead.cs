using Base.Models;
using Base.Services;
using BaseApi.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class LeaveSignRead
    {
        private ReadDto GetDto()
        {
            var locale = _Locale.GetLocaleNoDash();
            return new ReadDto()
            {
                ReadSql = $@"
select 
    s.Id, s.NodeName,
    l.StartTime, l.EndTime, l.Hours, l.Created,
    UserName=u2.Name,
    LeaveName=c.Name_{locale}
from dbo.XpFlowSign s
join dbo.XpFlow f on f.Code='Leave' and s.FlowId=f.Id
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel
join dbo.XpUser u on s.SignerId=u.Id
join dbo.XpUser u2 on l.UserId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.SignerId='{_Fun.UserId()}'
order by l.Created
",
            };
        }

        public async Task<JObject?> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(GetDto(), dt, ctrl);
        }

    } //class
}