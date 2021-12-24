using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class XpRoleController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for edit view
            await using (var db = new Db())
            {
                var locale0 = _Xp.GetLocale0();
                ViewBag.Users = await _XpCode.GetUsersAsync(db);
                //ViewBag.Progs = await _XpCode.GetProgsAsync(locale0, db);
                ViewBag.AuthRanges = await _XpCode.GetAuthRangesAsync(locale0, db);
            }
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpRoleRead().GetPageAsync(Ctrl, dt));
        }

        private XpRoleEdit EditService()
        {
            return new XpRoleEdit(Ctrl);
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateAsync(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateAsync(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteAsync(key));
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

    }//class
}