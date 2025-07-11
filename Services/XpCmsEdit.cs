﻿using Base.Models;
using Base.Services;
using BaseApi.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class XpCmsEdit : BaseEditSvc
    {
        public XpCmsEdit(string ctrl) : base(ctrl) { }

        private string _cmsType = "";
        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.Cms",
                PkeyFid = "Id",
                ReadSql = @"
select c.*,
    CreatorName=u.Name,
    ReviserName=u2.Name
from dbo.Cms c
join dbo.XpUser u on c.Creator=u.Id
left join dbo.XpUser u2 on c.Reviser=u2.Id
where c.Id=@Id
",
                Items = new EitemDto[] 
				{
                    new() { Fid = "Id" },
					new() { Fid = "CmsType", Value = _cmsType },
                    //new() { Fid = "DataType", Value = "0" },
                    new() { Fid = "Title", Required = true },
                    new() { Fid = "Text" },
					new() { Fid = "Html" },
					new() { Fid = "Note" },
                    new() { Fid = "FileName" },
                    new() { Fid = "StartTime", Required = true },
                    new() { Fid = "EndTime", Required = true },
                    new() { Fid = "Status" },
                },
            };
        }

        public async Task<ResultDto> CreateA(JObject json, IFormFile t0_FileName, string dirUpload, string cmsType)
        {
            _cmsType = cmsType;
            var service = EditSvc();
            var result = await service.CreateA(json);
            if (_Valid.ResultStatus(result))
                await _HttpFile.SaveCrudFileA(json, service.GetNewKeyJson(), dirUpload, t0_FileName, nameof(t0_FileName));
            return result;
        }

        public async Task<ResultDto> UpdateA(string key, JObject json, IFormFile t0_FileName, string dirUpload)
        {
            var service = EditSvc();
            var result = await service.UpdateA(key, json);
            if (_Valid.ResultStatus(result))
                await _HttpFile.SaveCrudFileA(json, service.GetNewKeyJson(), dirUpload, t0_FileName, nameof(t0_FileName));
            return result;
        }

    } //class
}
