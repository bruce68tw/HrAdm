using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class CustInputRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select * from dbo.CustInput
order by Id
",
            Items = new QitemDto[] {
                new() { Fid = "FldText" },
            },
        };

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

    } //class
}