using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class XpFlowSignRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select a.SourceId, a.SignerName, a.SignTime,
	FlowCode=f.Code, FlowName=f.Name
from dbo.XpFlowSign a
join dbo.XpFlow f on a.FlowId=f.Id
where a.FlowLevel=0
order by a.SignTime
",            
            TableAs = "a",
            Items = new QitemDto[] {
                new() { Fid = "SignTime", Type = QitemTypeEnum.Date },
                new() { Fid = "FlowId", Col = "f.Id" },
                //new() { Fid = "FlowStatus" },
            },
        };

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

    } //class
}