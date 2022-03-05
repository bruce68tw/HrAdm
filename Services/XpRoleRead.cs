using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class XpRoleRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select * from dbo.XpRole
order by Id
",
            Items = new QitemDto[] {
                new() { Fid = "Name", Op = ItemOpEstr.Like },
            },
        };

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

    } //class
}