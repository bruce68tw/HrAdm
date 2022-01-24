using Base.Models;
using BaseApi.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class LeaveSignController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            ViewBag.SignStatuses2 = await _XpCode.GetSignStatuses2Async(locale0);
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new LeaveSignRead().GetPageAsync(Ctrl, dt));
        }

        private LeaveSignEdit EditService()
        {
            return new LeaveSignEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
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
            return Json(await _XpFlow.SignRowAsync(id, (status == "Y"), note, "Leave", false));
        }

        //TODO: add your code
        //get file/image
        public async Task<FileResult> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewLeaveAsync(fid, key, ext);
        }

    }//class
}