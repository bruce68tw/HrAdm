using Base.Models;
using BaseApi.Attributes;
using BaseApi.Controllers;
using BaseApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpTranLogController : BaseCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XgTranLogR().GetPageA(Ctrl, dt));
        }

    }//class
}