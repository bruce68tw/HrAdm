using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class XpUserRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select u.*, 
    d.Name as DeptName
from dbo.XpUser u
join dbo.XpDept d on u.DeptId=d.Id
order by u.Name
",
            TableAs = "u",
            Items = [
                new() { Fid = "Account", Op = QitemOpEstr.Like },
                new() { Fid = "Name", Op = QitemOpEstr.Like },
                new() { Fid = "DeptId" },
            ],
        };

        public async Task<JObject?> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(dto, dt, ctrl);
        }

    } //class
}