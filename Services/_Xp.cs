using Base.Services;
using BaseApi.Services;
using BaseWeb.Services;
using HrAdm.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    //project service
    public static class _Xp
    {
        //public const string SiteVer = "20201228f";     //for my.js/css
        public static string MyVer = _Date.NowSecStr(); //for my.js/css
        public const string LibVer = "20220601b";       //for lib.js/css

        //public static string NoImagePath = _Fun.DirRoot + "/wwwroot/image/noImage.jpg";

        //SignRows View
        public static string SignRowsView = "~/Views/Leave/_SignRows.cshtml";

        //dir
        public static string DirTpl = _Fun.Dir("_template");
        public static string DirUpload = _Fun.Dir("_upload");
        //
        public static string DirLeave = DirUpload2("Leave");
        public static string DirUserExt = DirUpload2("UserExt");
        public static string DirUserLicense = DirUpload2("UserLicense");
        public static string DirCustInput = DirUpload2("CustInput");
        public static string DirUserImport = DirUpload2("UserImport");
        //dir cms
        public static string DirCms = DirUpload2("Cms", false);

        //public static string Locale;
        //public static string LocaleNoDash;

        //view columns 
        //public static int[] ViewCols = new int[] { 12, 2, 3 };

        public static MyContext GetDb()
        {
            return new MyContext();
        }

        #region get file path
        public static string PathUserExt(string key, string ext)
        {
            //return _File.GetFirstPath(DirUserExt, "PhotoFile_" + key, NoImagePath);
            return $"{DirUserExt}PhotoFile_{key}.{ext}";
        }
        #endregion

        private static string DirUpload2(string subDir, bool sep = true)
        {
            return DirUpload + subDir + (sep ? _Fun.DirSep : "");
        }

        public static string DirCmsType(string cmsType)
        {
            return DirCms + cmsType + _Fun.DirSep;
        }

        #region get file content
        public static async Task<FileResult?> ViewLeaveA(string fid, string key, string ext)
        {
            return await ViewFileA(DirLeave, fid, key, ext);
        }
        
        public static async Task<FileResult?> ViewUserExtA(string fid, string key, string ext)
        {
            //return _WebFile.EchoImage(PathUserExt(key));
            return await ViewFileA(DirUserExt, fid, key, ext);
        }
        public static async Task<FileResult?> ViewUserLicenseA(string fid, string key, string ext)
        {
            return await ViewFileA(DirUserLicense, fid, key, ext);
        }
        public static async Task<FileResult?> ViewCmsTypeA(string fid, string key, string ext, string cmsType)
        {
            return await ViewFileA(DirCmsType(cmsType), fid, key, ext);
        }
        public static async Task<FileResult?> ViewCustInputA(string fid, string key, string ext)
        {
            return await ViewFileA(DirCustInput, fid, key, ext);
        }

        private static async Task<FileResult?> ViewFileA(string dir, string fid, string key, string ext)
        {
            var path = $"{dir}{fid}_{key}.{ext}";
            return await _HttpFile.ViewFileA(path, $"{fid}.{ext}");
        }

        #endregion

        /// <summary>
        /// get locale code without dash sign
        /// </summary>
        /// <returns></returns>
        public static string GetLocale0()
        {
            return _Locale.GetLocaleByUser(false);
        }

        /// <summary>
        /// get template file
        /// </summary>
        /// <returns></returns>
        public static string GetTplPath(string fileName, bool hasLocale)
        {
            var dir = DirTpl;
            if (hasLocale)
                dir += _Locale.GetLocaleByUser() + _Fun.DirSep;

            return dir + fileName;
        }

        #region remmark code
        /*
        //constructor
        static _Xp()
        {
            Locale = _Config.GetStr("Locale", "zh-TW");
            LocaleNoDash = Locale.Replace("-", "");
        }
        */

        /*
        //constant
        //上傳檔案最大限制, 單位MB
        public const int UploadFileMax = 5;

        //檢查上傳檔案
        //後端程式不顯示詳細錯誤訊息到前端
        public static ErrorModel CheckUploadFile(HttpPostedFileBase file, int size, string exts)
        {
            var error = new ErrorModel();
            if (!_WebFile.CheckFileSize(file, size))
                error.ErrorMsg = "上傳檔案大小有誤。";
            else if(!_WebFile.CheckFileExt(file, exts))
                error.ErrorMsg = "上傳檔案種類有誤。";

            return error;
        }

        //儲存上傳檔案, 傳回路徑, 如果失敗則傳回空白
        public static string SaveUploadFile(HttpPostedFileBase file)
        {
            //rename existed file if any
            var dir = _Fun.DirRoot + "ImportFiles\\";
            var name = file.FileName;
            var path = dir + Path.GetFileName(name);
            if (File.Exists(path))
            {
                var path2 = dir + Path.GetFileNameWithoutExtension(name) + "_" + _Date.NowSecStr() + Path.GetExtension(name);
                File.Move(path, path2);
            }
            return _WebFile.SaveUploadFile(file, path) ? path : "";
        }

        //switch locale
        public static void SetLocale(string locale)
        {
            _Locale.SetCulture(locale);
        }

        //??
        //功能清單(名稱)設定多國語內容(recursive)
        public static void MenuSetLocale(List<MenuModel> menus)
        {
            //??
            var rm = _Locale.GetResourceFile("");
            rm.GetString("");
        }
        */
        #endregion

    }//class
}