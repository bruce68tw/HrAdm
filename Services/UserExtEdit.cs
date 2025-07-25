﻿using Base.Models;
using Base.Services;
using BaseApi.Services;
using Newtonsoft.Json.Linq;

namespace HrAdm.Services
{
    public class UserExtEdit : BaseEditSvc
    {
        public UserExtEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.XpUser",
                PkeyFid = "Id",
                Col4 = null,
                Items =
				[
					new() { Fid = "Id" },
					new() { Fid = "Account" },
					new() { Fid = "Name" },
					new() { Fid = "DeptId" },
                    new() { Fid = "PhotoFile" },
                    new() { Fid = "Status" },
                ],
                Childs =
				[
					new EditDto
                    {
                        Table = "dbo.[UserJob]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = [
							new() { Fid = "Id" },
							new() { Fid = "UserId" },
							new() { Fid = "JobName", Required = true },
							new() { Fid = "JobType" },
							new() { Fid = "JobPlace" },
							new() { Fid = "StartEnd", Required = true },
							new() { Fid = "CorpName", Required = true },
							new() { Fid = "CorpUsers" },
							new() { Fid = "IsManaged" },
							new() { Fid = "JobDesc" },
                        ],
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserSchool]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = [
							new() { Fid = "Id" },
							new() { Fid = "UserId" },
							new() { Fid = "SchoolName", Required = true },
							new() { Fid = "SchoolDept", Required = true },
							new() { Fid = "SchoolType" },
							new() { Fid = "StartEnd", Required = true },
							new() { Fid = "Graduated" },
                        ],
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserLang]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
						OrderBy = "Sort",
                        Col4 = null,
                        Items = [
							new() { Fid = "Id" },
							new() { Fid = "UserId" },
							new() { Fid = "LangName", Required = true },
							new() { Fid = "ListenLevel" },
							new() { Fid = "SpeakLevel" },
							new() { Fid = "ReadLevel" },
							new() { Fid = "WriteLevel" },
							new() { Fid = "Sort" },
                        ],
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserLicense]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = [
							new() { Fid = "Id" },
							new() { Fid = "UserId" },
							new() { Fid = "LicenseName", Required = true },
							new() { Fid = "StartEnd", Required = true },
							new() { Fid = "FileName" },
                        ],
                    },
                    new EditDto
                    {
                        Table = "dbo.[UserSkill]",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = [
							new() { Fid = "Id" },
							new() { Fid = "UserId" },
							new() { Fid = "SkillName", Required = true },
							new() { Fid = "SkillDesc" },
							new() { Fid = "Sort" },
                        ],
                    },
                ],
            };
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> CreateA(JObject json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            var service = EditSvc();
            var result = await service.CreateA(json);
            if (_Valid.ResultStatus(result))
            {
                var newKeyJson = service.GetNewKeyJson();
                await _HttpFile.SaveCrudFileA(json, newKeyJson, _Xp.DirUserExt, t0_PhotoFile, nameof(t0_PhotoFile));
                await _HttpFile.SaveCrudFilesA(json, newKeyJson, _Xp.DirUserLicense, t03_FileName, nameof(t03_FileName));
            }
            return result;
        }

        //TODO: add your code
        //t03_FileName: t + table serial _ + fid
        public async Task<ResultDto> UpdateA(string key, JObject json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            var service = EditSvc();
            var result = await service.UpdateA(key, json);
            if (_Valid.ResultStatus(result))
            {
                var newKeyJson = service.GetNewKeyJson();
                await _HttpFile.SaveCrudFileA(json, newKeyJson, _Xp.DirUserExt, t0_PhotoFile, nameof(t0_PhotoFile));
                await _HttpFile.SaveCrudFilesA(json, newKeyJson, _Xp.DirUserLicense, t03_FileName, nameof(t03_FileName));
            }
            return result;
        }

    } //class
}
