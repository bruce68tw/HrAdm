using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class UserExtController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
			//for read view
			ViewBag.Depts = await _XpCode.DeptsA();
			//for edit view
			ViewBag.LangLevels = await _XpCode.LangLevelsA(_Xp.GetLocale0());
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserExtRead().GetPageA(Ctrl, dt));
        }

        private UserExtEdit EditService()
        {
            return new UserExtEdit(Ctrl);
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_PhotoFile, List<IFormFile> t03_FileName)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json), t0_PhotoFile, t03_FileName));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_PhotoFile, 
            List<IFormFile> t03_FileName)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json), t0_PhotoFile, t03_FileName));
        }

        //TODO: add your code
        //get file/image
        public async Task<FileResult> ViewFile(string table, string fid, string key, string ext)
        {
            return (fid == "PhotoFile")
                ? await _Xp.ViewUserExtA(fid, key, ext)
                : await _Xp.ViewUserLicenseA(fid, key, ext);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

        //generate word resume
        public async Task GenWord(string id)
        {
            //for testing exception
            //_Fun.Except();

            await new UserExtService().GenWordA(id);
        }

    }//class
}