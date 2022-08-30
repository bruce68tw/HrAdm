using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using BaseWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpEasyRptController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XgEasyRptRead().GetPageA(Ctrl, dt));
        }

        private XgEasyRptEdit EditService()
        {
            return new XgEasyRptEdit(Ctrl);
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

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

    }//class
}