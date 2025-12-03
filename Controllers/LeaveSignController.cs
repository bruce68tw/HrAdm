using Base.Enums;
using Base.Models;
using BaseApi.Attributes;
using BaseApi.Controllers;
using BaseApi.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class LeaveSignController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for read view
            var locale = _Locale.GetLocaleNoDash();
            ViewBag.SignStatuses2 = await _XpCode.SignStatuses2A(locale);
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new LeaveSignRead().GetPageA(Ctrl, dt));
        }

        private LeaveSignEdit EditService()
        {
            return new LeaveSignEdit(Ctrl);
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

        /// <summary>
        /// sign one row
        /// </summary>
        /// <param name="id">XpFlowSign.Id</param>
        /// <param name="status">signStatus</param>
        /// <param name="note">sign note</param>
        /// <returns>ResultDto</returns>
        [HttpPost]
        public async Task<JsonResult> SignRow(string id, string status, string note)
        {
            return Json(await _XgFlow.SignRowA(id, (status == "Y"), note, "Leave", false, FlowBackTypeEnum.ToPrev));
        }

        //TODO: add your code
        //get file/image
        public async Task<FileResult?> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewLeaveA(fid, key, ext);
        }

    }//class
}