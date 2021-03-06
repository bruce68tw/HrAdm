using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class UserExtEdit : XpEdit
    {
        public UserExtEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[User]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new [] 
				{
					new EitemDto { Fid = "Id" },
					new EitemDto { Fid = "Account" },
					new EitemDto { Fid = "Name" },
					new EitemDto { Fid = "DeptId" },
                    new EitemDto { Fid = "PhotoFile" },
                    new EitemDto { Fid = "Status" },
                },
                Childs = new EditDto[]
                {
                    new EditDto
                    {
                        Table = "dbo.[UserJob]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "JobName", Required = true },
							new EitemDto { Fid = "JobType" },
							new EitemDto { Fid = "JobPlace" },
							new EitemDto { Fid = "StartEnd", Required = true },
							new EitemDto { Fid = "CorpName", Required = true },
							new EitemDto { Fid = "CorpUsers" },
							new EitemDto { Fid = "IsManaged" },
							new EitemDto { Fid = "JobDesc" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserSchool]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "SchoolName", Required = true },
							new EitemDto { Fid = "SchoolDept", Required = true },
							new EitemDto { Fid = "SchoolType" },
							new EitemDto { Fid = "StartEnd", Required = true },
							new EitemDto { Fid = "Graduated" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserLang]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
						OrderBy = "Sort",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "LangName", Required = true },
							new EitemDto { Fid = "ListenLevel" },
							new EitemDto { Fid = "SpeakLevel" },
							new EitemDto { Fid = "ReadLevel" },
							new EitemDto { Fid = "WriteLevel" },
							new EitemDto { Fid = "Sort" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserLicense]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "LicenseName", Required = true },
							new EitemDto { Fid = "StartEnd", Required = true },
							new EitemDto { Fid = "FileName" },
                        },
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserSkill]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "SkillName", Required = true },
							new EitemDto { Fid = "SkillDesc" },
							new EitemDto { Fid = "Sort" },
                        },
                    },
                },
            };
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> CreateAsnyc(JObject json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            var service = Service();
            var result = service.Create(json);
            if (_Valid.ResultStatus(result))
            {
                var newKeyJson = service.GetNewKeyJson();
                await _WebFile.SaveCrudFileAsnyc(json, newKeyJson, _Xp.DirUserExt, t0_PhotoFile, nameof(t0_PhotoFile));
                await _WebFile.SaveCrudFilesAsnyc(json, newKeyJson, _Xp.DirUserLicense, t03_FileName, nameof(t03_FileName));
            }
            return result;
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> UpdateAsnyc(string key, JObject json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            var service = Service();
            var result = service.Update(key, json);
            if (_Valid.ResultStatus(result))
            {
                var newKeyJson = service.GetNewKeyJson();
                await _WebFile.SaveCrudFileAsnyc(json, newKeyJson, _Xp.DirUserExt, t0_PhotoFile, nameof(t0_PhotoFile));
                await _WebFile.SaveCrudFilesAsnyc(json, newKeyJson, _Xp.DirUserLicense, t03_FileName, nameof(t03_FileName));
            }
            return result;
        }

    } //class
}
