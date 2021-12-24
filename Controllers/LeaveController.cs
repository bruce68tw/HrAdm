using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Attributes;
using BaseApi.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class LeaveController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            ViewBag.LeaveTypes = await _XpCode.GetLeaveTypesAsync(locale0);
			ViewBag.SignStatuses = await _XpCode.GetSignStatusesAsync(locale0);
			//for edit view
			ViewBag.Users = await _XpCode.GetUsersAsync();
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new LeaveRead().GetPageAsync(Ctrl, dt));
        }

        private LeaveEdit EditService()
        {
            return new LeaveEdit(Ctrl);
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Create)]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateAsnyc(_Str.ToJson(json), t0_FileName));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateAsnyc(key, _Str.ToJson(json), t0_FileName));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Delete)]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteAsync(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

        //get file/image
        public async Task<FileResult> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewLeaveAsync(fid, key, ext);
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">Leave.Id</param>
        /// <returns></returns>
        public ActionResult GetSignRows(string id)
        {
            return PartialView("_SignRows", new LeaveService().GetSignRows(id));
        }

    }//class
}