using Base.Models;
using Base.Services;
using BaseApi.Attributes;
using BaseApi.Controllers;
using BaseApi.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpFlowController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            await using(var db = new Db())
            {
                var locale0 = _Xp.GetLocale0();
                ViewBag.NodeTypes = await _XpCode.NodeTypesA(locale0, db);
                ViewBag.SignerTypes = await _XpCode.SignerTypesA(locale0, db);
                ViewBag.AndOrs = await _XpCode.AndOrsA(locale0, db);
                ViewBag.LineOps = await _XpCode.LineOpsA(locale0, db);
                ViewBag.LineFromTypes = await _XpCode.LineFromTypesA(locale0, db);
            }
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XgFlowR().GetPageA(Ctrl, dt));
        }

        private XgFlowE EditService()
        {
            return new XgFlowE(Ctrl);
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
            return Json(await EditService().CreateA(_Str.ToJson(json)!));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)!));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

        //test flow
        //code: flow.Code
        //json: flow data in json string
        [HttpPost]
        public async Task<string> SaveTest(string code, string data)
        {
            return await new TestFlowService().StartFlow(code, data);
        }

    } //class
}