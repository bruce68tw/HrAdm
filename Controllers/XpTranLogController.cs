using Base.Models;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using BaseWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpTranLogController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XgTranLogRead().GetPageAsync(Ctrl, dt));
        }

    }//class
}