using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseApi.Services;
using BaseApi.Attributes;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class CustInputController : BaseCtrl
    {
        public ActionResult Read()
        {
            //for testing exception
            //_Fun.Except();

			//for edit view
			ViewBag.Radios = _XpCode.GetRadios();
			ViewBag.Selects = _XpCode.GetSelects();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            //testing error case
            //return JsonToCnt(_Json.GetError());

            return JsonToCnt(await new CustInputRead().GetPageA(Ctrl, dt));
        }

        private CustInputEdit EditService()
        {
            return new CustInputEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            //_Fun.Except();
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            //_Fun.Except();
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Create(string json, IFormFile t0_FldFile)
        {
            //_Fun.Except();
            return Json(await EditService().CreateA(_Str.ToJson(json)!, t0_FldFile));
        }

        [HttpPost]
        //TODO: add your code, tSn_fid ex: t03_FileName
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FldFile)
        {
            //_Fun.Except();
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)!, t0_FldFile));
        }

        //TODO: add your code
        //get file/image
        public async Task<FileResult?> ViewFile(string table, string fid, string key, string ext)
        {
            //for testing exception
            //_Fun.Except();

            return await _Xp.ViewCustInputA(fid, key, ext);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            //testing error case
            //return Json(_Model.GetError());

            return Json(await EditService().DeleteA(key));
        }

        /// <summary>
        /// upload html image, image fileName: _Str.NewId() string
        /// </summary>
        /// <param name="file"></param>
        /// <returns>return image url</returns>
        public async Task<string> SetHtmlImage(IFormFile file)
        {
            var subDir = "image/CustInput";
            var fileName = await _HttpFile.SaveFileByNewIdA(file, $"{_FunApi.DirWeb}{subDir}");
            return _Fun.GetHtmlImageUrl($"{subDir}/{fileName}");
        }

    }//class
}