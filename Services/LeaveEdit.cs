using Base.Models;
using Base.Services;
using BaseApi.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class LeaveEdit : BaseEditSvc
    {
        public LeaveEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            var locale = _Locale.GetLocaleNoDash();
            return new EditDto
            {
                FnAfterSaveA = FnAfterSaveA,
				Table = "dbo.Leave",
                PkeyFid = "Id",
                ReadSql = $@"
select l.*,
    FlowStatusName=c.Name_{locale},
    CreatorName=u.Name,
    ReviserName=u2.Name,
    {_Fun.FidUser}=u3.Id, {_Fun.FidDept}=u3.DeptId
from dbo.Leave l
join dbo.XpCode c on c.Type='FlowStatus' and l.FlowStatus=c.Value
join dbo.XpUser u on l.Creator=u.Id
left join dbo.XpUser u2 on l.Reviser=u2.Id
join dbo.XpUser u3 on l.UserId=u3.Id
where l.Id=@Id
",
                Items =
                [
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
                ],
            };
        }

        //private string _newKey;
        private JObject? _inputRow;

        public async Task<ResultDto> CreateA(JObject json, IFormFile t0_FileName)
        {
            _inputRow = _Json.GetRows0(json)!;
            var service = EditSvc();
            var result = await service.CreateA(json);
            if (_Valid.ResultStatus(result))
                await _HttpFile.SaveCrudFileA(json, service.GetNewKeyJson(), _Xp.DirLeave, t0_FileName, nameof(t0_FileName));
            return result;
        }

        public async Task<ResultDto> UpdateA(string key, JObject json, IFormFile t0_FileName)
        {
            var service = EditSvc();
            var result = await service.UpdateA(key, json);
            if (_Valid.ResultStatus(result))
                await _HttpFile.SaveCrudFileA(json, service.GetNewKeyJson(), _Xp.DirLeave, t0_FileName, nameof(t0_FileName));
            return result;
        }

        //delegate function of FnAfterSave
        //Create Sign Rows 
        private async Task<string> FnAfterSaveA(bool isNew, CrudEditSvc crudEditSvc, Db db, JObject newKeyJson)
        {
            if (!isNew) return "";

            var newKey = _Str.ReadNewKeyJson(newKeyJson);
            return await _XgFlow.CreateSignRowsA(_inputRow!, "UserId", "Leave", newKey, false, db);
        }

    } //class
}
