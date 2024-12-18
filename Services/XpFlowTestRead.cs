using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class XpFlowTestRead
    {
        private ReadDto GetDto(string userId)
        {
            return new()
            {
                //目前簽核者為登入者才可簽核(CanSign)
                ReadSql = $@"
select 
    f.Name as FlowName, x.Name_zhTW as FlowStatusName, 
    case when d.FlowStatus='0' then s.NodeName else '' end as NodeName, 
    u.Name as SignerName,
	d.Created, d.Id,
    case when (d.FlowStatus='0' and s.SignerId='{userId}') then 1 else 0 end as CanSign
from dbo.XpFlowTest d 
join dbo.XpFlowSignTest s on s.SourceId=d.Id and s.FlowLevel=d.FlowLevel
join dbo.XpFlow f on s.FlowId=f.Id
join dbo.XpCode x on x.Type='FlowStatus' and d.FlowStatus=x.Value
join dbo.XpUser u on s.SignerId=u.Id
order by d.Created desc
",
                TableAs = "d",
                Items = new QitemDto[] {
                    new() { Fid = "FlowId", Col = "f.Id" },
                    new() { Fid = "FlowStatus" },
                },
            };
        }

        public async Task<JObject?> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(GetDto(_Fun.UserId()), dt, ctrl);
        }

    } //class
}