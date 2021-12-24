using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    public class XpEasyRptController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpEasyRptRead().GetPageAsync(Ctrl, dt));
        }

        private XpEasyRptEdit EditService()
        {
            return new XpEasyRptEdit(Ctrl);
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

    }//class
}