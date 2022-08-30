using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using HrAdm.Models;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //CMS base controller, abstract class
    abstract public class XpCmsController : ApiCtrl 
    {
        //public string ProgName;     //program name
        public string CmsType;      //map to CmsTypeEstr
        public string DirUpload;    //upload dir, no right slash
        public CmsEditDto EditDto;

        //use shared view
        public ActionResult Read()
        {			
            //ViewBag.ProgName = ProgName;
            ViewBag.CmsType = CmsType;
            return View("/Views/XpCms/Read.cshtml", EditDto); //public view
        }

        //read rows with cmsType
        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpCmsRead(CmsType).GetPageA(Ctrl, dt));
        }

        private XpCmsEdit EditService()
        {
            return new XpCmsEdit(Ctrl);
        }

        //by dirUpload & cmsType
        [HttpPost]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json), t0_FileName, DirUpload, CmsType));
        }

        //by dirUpload
        [HttpPost]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json), t0_FileName, DirUpload));
        }

        //by cmsType
        public async Task<FileResult> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewCmsTypeA(fid, key, ext, CmsType);
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

    }//class
}