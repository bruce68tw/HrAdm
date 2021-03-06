using Base.Models;
using Base.Services;
using BaseWeb.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    public class CustInputController : XpCtrl
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
        public ContentResult GetPage(DtDto dt)
        {
            //testing error case
            //return JsonToCnt(_Json.GetError());

            return JsonToCnt(new CustInputRead().GetPage(Ctrl, dt));
        }

        private CustInputEdit EditService()
        {
            return new CustInputEdit(Ctrl);
        }

        [HttpPost]
        public ContentResult GetUpdateJson(string key)
        {
            //_Fun.Except();
            return JsonToCnt(EditService().GetUpdateJson(key));
        }

        [HttpPost]
        public ContentResult GetViewJson(string key)
        {
            //_Fun.Except();
            return JsonToCnt(EditService().GetViewJson(key));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FldFile)
        {
            //_Fun.Except();
            return Json(await EditService().CreateAsnyc(_Json.StrToJson(json), t0_FldFile));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FldFile)
        {
            //_Fun.Except();
            return Json(await EditService().UpdateAsnyc(key, _Json.StrToJson(json), t0_FldFile));
        }

        //get file/image
        public FileResult ViewFile(string table, string fid, string key, string ext)
        {
            //for testing exception
            //_Fun.Except();

            return _Xp.ViewCustInput(fid, key, ext);
        }

        [HttpPost]
        public JsonResult Delete(string key)
        {
            //testing error case
            //return Json(_Model.GetError());

            return Json(EditService().Delete(key));
        }

        /// <summary>
        /// upload html image, image fileName: time string
        /// </summary>
        /// <param name="file"></param>
        /// <param name="prog"></param>
        /// <returns>return url</returns>
        public async Task<string> SetHtmlImage(IFormFile file, string prog)
        {
            var fileName = await _WebFile.SaveHtmlImage(file, prog);
            return $"/image/{prog}/{fileName}";
        }

    }//class
}