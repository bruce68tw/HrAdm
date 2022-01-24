using Base.Enums;
using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpFlowTestController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            await using var db = new Db();
            ViewBag.Flows = await _XpCode.GetFlowsAsync(db);
			ViewBag.FlowStatuses = await _XpCode.GetFlowStatusesAsync(locale0, db);
			//for edit view
            ViewBag.SignStatuses2 = await _XpCode.GetSignStatuses2Async(locale0, db);
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpFlowTestRead().GetPageAsync(Ctrl, dt));
        }

        private XpFlowTestEdit EditService(string flowCode)
        {
            return new XpFlowTestEdit(Ctrl, flowCode);
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<ContentResult> GetUpdJson(string flowCode, string key)
        {
            return JsonToCnt(await EditService(flowCode).GetUpdJsonAsync(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public async Task<ContentResult> GetViewJson(string flowCode, string key)
        {
            return JsonToCnt(await EditService(flowCode).GetViewJsonAsync(key));
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">XpFlowTest.Id</param>
        /// <returns></returns>
        public ActionResult GetSignRows(string id)
        {
            return PartialView(_Xp.SignRowsView, new XpFlowTestService().GetSignRows(id));
        }

        [HttpPost]
        public async Task<JsonResult> SignRow(string id, string status, string note)
        {
            return Json(await _XpFlow.SignRowAsync(id, (status == "Y"), note, "XpFlowTest", true));
        }

    }//class
}