using Base.Enums;
using Base.Models;
using Base.Services;
using BaseApi.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class LeaveRead
    {
        private ReadDto GetReadDto()
        {
            var locale = _Locale.GetLocale();
            return new ReadDto()
            {
                ReadSql = $@"
select 
    u.Name as UserName, u2.Name as AgentName,
    c.Name_{locale} as LeaveName, l.StartTime,
    l.EndTime, l.Hours,
    c2.Name_{locale} as SignStatusName, l.Created,
    l.Id
from dbo.Leave l
join dbo.XpUser u on l.UserId=u.Id
join dbo.XpUser u2 on l.AgentId=u2.Id
join dbo.XpCode c on c.Type='LeaveType' and l.LeaveType=c.Value
join dbo.XpCode c2 on c2.Type='FlowStatus' and l.FlowStatus=c2.Value
order by l.Id
",
                Items = [
                    new() { Fid = "StartTime", Type = QitemTypeEnum.Date },
                    new() { Fid = "LeaveType" },
                    new() { Fid = "FlowStatus" },
                ],
            };
        }

        public async Task<JObject?> GetPageA(string ctrl, DtDto dtDto)
        {
            return await new CrudReadSvc().GetPageA(GetReadDto(), dtDto, ctrl);
        }

    } //class
}