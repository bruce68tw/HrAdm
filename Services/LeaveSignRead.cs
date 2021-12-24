using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class LeaveSignRead
    {
        private ReadDto GetDto()
        {
            var locale = _Xp.GetLocale0();
            return new ReadDto()
            {
                ReadSql = $@"
select 
    s.Id, s.NodeName,
    l.StartTime, l.EndTime, l.Hours, l.Created,
    UserName=u.Name,
    LeaveName=c.Name_{locale}
from dbo.XpFlowSign s
join dbo.XpFlow f on f.Code='Leave' and s.FlowId=f.Id
join dbo.Leave l on s.SourceId=l.Id and s.FlowLevel=l.FlowLevel and s.SignStatus='0'
join dbo.[User] u on l.UserId=u.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
where s.SignerId='{_Fun.UserId()}'
order by l.Created
",
            };
        }

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(GetDto(), dt, ctrl);
        }

    } //class
}