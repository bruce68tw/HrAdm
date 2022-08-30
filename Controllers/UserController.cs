using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class UserController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
			//for read view
			ViewBag.Depts = await _XpCode.DeptsA();
			//for edit view
			ViewBag.Roles = await _XpCode.RolesA();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new UserRead().GetPageA(Ctrl, dt));
        }

        private UserEdit EditService()
        {
            return new UserEdit(Ctrl);
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
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

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

    }//class
}