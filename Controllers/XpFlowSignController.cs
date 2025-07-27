using Base.Models;
using BaseApi.Attributes;
using BaseApi.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpFlowSignController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for read view
            ViewBag.Flows = await _XpCode.FlowsA();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpFlowSignRead().GetPageA(Ctrl, dt));
        }

        private XpFlowSignEdit EditSvc(string flowCode)
        {
            return new XpFlowSignEdit(Ctrl, flowCode);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string flowCode, string key)
        {
            return JsonToCnt(await EditSvc(flowCode).GetUpdJsonA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string flowCode, string key)
        {
            return JsonToCnt(await EditSvc(flowCode).GetViewJsonA(key));
        }

        //get file/image
        public async Task<FileResult?> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewLeaveA(fid, key, ext);
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">Leave.Id</param>
        /// <returns></returns>
        public ActionResult GetSignRows(string id)
        {
            return PartialView(_Xp.SignRowsView, new LeaveService().GetSignRows(id));
        }

    }//class
}