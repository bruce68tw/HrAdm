using BaseWeb.Attributes;
using HrAdm.Enums;
using HrAdm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //1.inherit
    [XgProgAuth]
    public class UserImportController : XpImportController
    {
        //2.constructor
        public UserImportController()
        {
            //ProgName = "Import User";
            ImportType = ImportTypeEstr.User;
            TplPath = _Xp.DirTpl + "/UserImport.xlsx";
            DirUpload = _Xp.DirUserImport;
        }

        //3.override
        [HttpPost]
        override public async Task<JsonResult> Import(IFormFile file)
        {
            var model = await new UserImportService().ImportAsync(file, this.DirUpload);
            return Json(model);
        }

    }//class
}