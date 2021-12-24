using Base.Models;
using BaseApi.Controllers;
using BaseWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    //Excel import base controller
    abstract public class XpImportController : ApiCtrl 
    {
        //public string ProgName;     //program display name
        public string ImportType;   //map to ImportLog.Type
        public string TplPath;      //template file path
        public string DirUpload;    //upload dir, no right slash

        public ActionResult Read()
        {			
            //ViewBag.ProgName = ProgName;
            ViewBag.ImportType = ImportType;
            return View("/Views/XpImport/Read.cshtml"); //public view
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpImportRead(ImportType).GetPageAsync(Ctrl, dt));
        }

        //run import, drived class implement !!
        //abstract could not be async(CS1994), must use virtual method !!
        virtual public async Task<JsonResult> Import(IFormFile file) 
        { 
            return await Task.FromResult<JsonResult>(null); ;
        }

        /// <summary>
        /// download template file
        /// </summary>
        /// <param name="file">file name</param>
        /// <returns>file</returns>
        public async Task<FileResult> Template()
        {
            return await _WebFile.ViewFileAsync(TplPath);  //use this instead of PhysicalFile()
        }

        //download source import file
        public async Task<FileResult> GetSource(string id, string name)
        {
            return await GetFile(id, name);
            /*
            var file = GetFile(id, name);
            return (file == null)
                ? NotFound() : file;
            */
        }

        //download failed import file
        public async Task<FileResult> GetFail(string id, string name)
        {
            return await GetFile(id + "_fail", name);
        }

        //download import file
        private async Task<FileResult> GetFile(string realFileStem, string downFileName)
        {
            return await _WebFile.ViewFileAsync($"{DirUpload}/{realFileStem}.xlsx", downFileName);
        }

    }//class
}