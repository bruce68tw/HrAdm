using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class UserRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select u.Id, u.Account, u.Name, u.Status,
   d.Name as DeptName
from dbo.[User] u
join dbo.Dept d on u.DeptId=d.Id
order by u.Name
",
            Items = new QitemDto[] {
                new() { Fid = "Account", Op = ItemOpEstr.Like },
                new() { Fid = "Name", Op = ItemOpEstr.Like },
                new() { Fid = "DeptId" },
            },
        };

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

    } //class
}