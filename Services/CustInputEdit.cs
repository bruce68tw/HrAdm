using Base.Models;
using Base.Services;
using BaseApi.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class CustInputEdit : BaseEditSvc
    {
        public CustInputEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.CustInput",
                PkeyFid = "Id",
                Col4 = null,
                AutoIdLen = 0,  //表示新增時可傳入主key
                Items =
                [
                    new() { Fid = "Id" },
                    new() { Fid = "FldCheck" },
                    new() { Fid = "FldDate" },
                    new() { Fid = "FldDt" },
                    new() { Fid = "FldDec" },
                    new() { Fid = "FldInt" },
                    new() { Fid = "FldFile" },
                    new() { Fid = "FldHtml", IsHtml = true },
                    //new() { Fid = "FldLink", Col = "FldFile" },
					new() { Fid = "FldRadio" },
                    new() { Fid = "FldRead", Col = "FldText" },
                    new() { Fid = "FldSelect" },
                    new() { Fid = "FldTextarea", Required = true },
                    new() { Fid = "FldText", Required = true },
					//new() { Fid = "FldColor", Required = true },
                ],
            };
        }

        public async Task<ResultDto> CreateA(JObject json, IFormFile t0_FldFile)
        {
            var service = EditSvc();
            var result = await service.CreateA(json);
            if (_Valid.ResultStatus(result))
                await _HttpFile.SaveCrudFileA(json, service.GetNewKeyJson(), _Xp.DirCustInput, t0_FldFile, nameof(t0_FldFile));
            return result;
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> UpdateA(string key, JObject json, IFormFile t0_FldFile)
        {
            var service = EditSvc();
            var result = await service.UpdateA(key, json);
            if (_Valid.ResultStatus(result))
                await _HttpFile.SaveCrudFileA(json, service.GetNewKeyJson(), _Xp.DirCustInput, t0_FldFile, nameof(t0_FldFile));
            return result;
        }

    } //class
}
