using Base.Enums;
using Base.Models;
using Base.Services;
using BaseApi.Attributes;
using BaseApi.Controllers;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgLogin]
    public class LeaveController : BaseCtrl
    {
        //[XgProgAuth(CrudEnum.Read)]
        public async Task<ActionResult> Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            ViewBag.LeaveTypes = await _XpCode.LeaveTypesA(locale0);
			ViewBag.SignStatuses = await _XpCode.SignStatusesA(locale0);
			//for edit view
			ViewBag.Users = await _XpCode.UsersA();
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new LeaveRead().GetPageA(Ctrl, dt));
        }

        private LeaveEdit EditService()
        {
            return new LeaveEdit(Ctrl);
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Create)]
        public async Task<JsonResult> Create(string json, IFormFile t0_FileName)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json)!, t0_FileName));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<JsonResult> Update(string key, string json, IFormFile t0_FileName)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)!, t0_FileName));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Delete)]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
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