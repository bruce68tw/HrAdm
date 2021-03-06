using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class UserExtRead
    {
        private ReadDto dto = new ReadDto()
        {
            ReadSql = @"
select u.*, d.name as DeptName from dbo.[User] u
join dbo.Dept d on u.DeptId=d.Id
order by u.Id
",
            Items = new [] {
                new QitemDto { Fid = "Account", Op = ItemOpEstr.Like },
                new QitemDto { Fid = "Name", Op = ItemOpEstr.Like },
                new QitemDto { Fid = "DeptId" },
            },
        };

        public JObject GetPage(string ctrl, DtDto dt)
        {
            return new CrudRead().GetPage(ctrl, dto, dt);
        }

    } //class
}