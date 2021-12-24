using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class LeaveEdit : XpEdit
    {
        public LeaveEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            var locale = _Xp.GetLocale0();
            return new EditDto
            {
				Table = "dbo.Leave",
                PkeyFid = "Id",
                ReadSql = $@"
select l.*,
    FlowStatusName=c.Name_{locale},
    CreatorName=u.Name,
    ReviserName=u2.Name,
    {_Fun.UserFid}=u3.Id, {_Fun.DeptFid}=u3.DeptId
from dbo.Leave l
join dbo.XpCode c on c.Type='FlowStatus' and l.FlowStatus=c.Value
join dbo.[User] u on l.Creator=u.Id
left join dbo.[User] u2 on l.Reviser=u2.Id
join dbo.[User] u3 on l.UserId=u3.Id
where l.Id='{{0}}'
",
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
					new() { Fid = "UserId", Required = true },
					new() { Fid = "AgentId", Required = true },
					new() { Fid = "LeaveType", Required = true },
					new() { Fid = "StartTime", Required = true },
					new() { Fid = "EndTime", Required = true },
					new() { Fid = "Hours", Required = true },
                    new() { Fid = "FileName" },
                    new() { Fid = "FlowLevel", Value = "1" },
                    new() { Fid = "FlowStatus", Value = "0" },
					new() { Fid = "Status", Value = 1 },
                },
            };
        }

        //private string _newKey;
        private JObject _inputRow;

        //delegate function of FnAfterSave
        private async Task<string> FnCreateSignRowsAsync(Db db, JObject newKeyJson)
        {
            var newKey = _Str.ReadNewKeyJson(newKeyJson);
            return await _XpFlow.CreateSignRowsAsync(_inputRow, "UserId", "Leave", newKey, db);
        }

        public async Task<ResultDto> CreateAsnyc(JObject json, IFormFile t0_FileName)
        {
            _inputRow = _Json.ReadInputJson0(json);
            var service = EditService();
            var result = await service.CreateAsync(json, null, FnCreateSignRowsAsync);
            if (_Valid.ResultStatus(result))
            {
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirLeave, t0_FileName, nameof(t0_FileName));
            }
            return result;
        }

        public async Task<ResultDto> UpdateAsnyc(string key, JObject json, IFormFile t0_FileName)
        {
            var service = EditService();
            var result = await service.UpdateAsync(key, json);
            if (_Valid.ResultStatus(result))
            {
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirLeave, t0_FileName, nameof(t0_FileName));
            }
            return result;
        }

    } //class
}
