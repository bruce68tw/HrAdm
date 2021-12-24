using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class CustInputEdit : XpEdit
    {
        public CustInputEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[CustInput]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new EitemDto[] 
				{
					new() { Fid = "Id" },
                    new() { Fid = "FldCheck", Required = true },
                    new() { Fid = "FldDate", Required = true },
                    new() { Fid = "FldDt", Required = true },
                    new() { Fid = "FldDec", Required = true },
                    new() { Fid = "FldInt", Required = true },
                    new() { Fid = "FldFile", Required = true },
                    new() { Fid = "FldHtml", Required = true },
                    new() { Fid = "FldLink", Col = "FldFile" },
					new() { Fid = "FldRadio", Required = true },
                    new() { Fid = "FldRead", Col = "FldText" },
                    new() { Fid = "FldSelect", Required = true },
                    new() { Fid = "FldTextarea", Required = true },
                    new() { Fid = "FldText", Required = true },
					//new() { Fid = "FldColor", Required = true },
                },
            };
        }

        public async Task<ResultDto> CreateAsnyc(JObject json, IFormFile t0_FldFile)
        {
            var service = EditService();
            var result = await service.CreateAsync(json);
            if (_Valid.ResultStatus(result))
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirCustInput, t0_FldFile, nameof(t0_FldFile));
            return result;
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> UpdateAsnyc(string key, JObject json, IFormFile t0_FldFile)
        {
            var service = EditService();
            var result = await service.UpdateAsync(key, json);
            if (_Valid.ResultStatus(result))
                await _WebFile.SaveCrudFileAsnyc(json, service.GetNewKeyJson(), _Xp.DirCustInput, t0_FldFile, nameof(t0_FldFile));
            return result;
        }

    } //class
}
