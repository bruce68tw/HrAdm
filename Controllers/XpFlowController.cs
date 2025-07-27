using Base.Models;
using Base.Services;
using BaseApi.Attributes;
using BaseApi.Controllers;
using BaseApi.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpFlowController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            await _XgFlow.ReadSetViewBagA(ViewBag, _Locale.GetLocale(false));
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XgFlowR().GetPageA(Ctrl, dt));
        }

        private XgFlowE EditSvc()
        {
            return new XgFlowE(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditSvc().GetUpdJsonA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditSvc().GetViewJsonA(key));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditSvc().CreateA(_Str.ToJson(json)!));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditSvc().UpdateA(key, _Str.ToJson(json)!));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditSvc().DeleteA(key));
        }

        /// <summary>
        /// test flow
        /// </summary>
        /// <param name="code">flow.Code</param>
        /// <param name="data">flow data in json string</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> SaveTest(string code, string data)
        {
            return await new TestFlowService().StartFlow(code, data);
        }

    } //class
}