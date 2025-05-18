using Base.Models;
using Base.Services;
using BaseApi.Services;

namespace HrAdm.Services
{
    public class UserExtService
    {
        /// <summary>
        /// generate word docu
        /// </summary>
        /// <param name="userId">User.Id</param>
        /// <return>error msg if any</return>
        public async Task<bool> GenWordA(string userId)
        {
            #region 1.check data && template file
            var error = "";
            if (_Str.IsEmpty(userId))
            {
                error = "UserId is need.";
                goto lab_error;
            }

            var tplPath = _Xp.GetTplPath("UserExt.docx", true);
            if (!File.Exists(tplPath))
            {
                error = "no file " + tplPath;
                goto lab_error;
            }
            #endregion

            #region 2.read row/rows by Linq
            var db = _Xp.GetDb();
            var user = db.XpUser
                .Select(a => a)
                .FirstOrDefault(a => a.Id == userId);

            var userJobs = db.UserJob
                .Where(a => a.UserId == userId)
                .Select(a => a)
                .ToList();

            var userSchools = db.UserSchool
                .Where(a => a.UserId == userId)
                .Select(a => new {
                    a.SchoolName,
                    a.SchoolDept,
                    a.SchoolType,
                    a.StartEnd,
                    Graduated = a.Graduated ? "(畢)" : "(肄)",
                })
                .ToList();

            var userLicenses = db.UserLicense
                .Where(a => a.UserId == userId)
                .Select(a => a)
                .ToList();

            string langLevel = "LangLevel";
            var locale = _Xp.GetLocale0();
            var userLangs = (from a in db.UserLang
                             join c1 in db.XpCode on new { Type = langLevel, Value = a.ListenLevel.ToString() } equals new { c1.Type, c1.Value }
                             join c2 in db.XpCode on new { Type = langLevel, Value = a.SpeakLevel.ToString() } equals new { c2.Type, c2.Value }
                             join c3 in db.XpCode on new { Type = langLevel, Value = a.ReadLevel.ToString() } equals new { c3.Type, c3.Value }
                             join c4 in db.XpCode on new { Type = langLevel, Value = a.WriteLevel.ToString() } equals new { c4.Type, c4.Value }
                             where a.UserId == userId
                             orderby a.Sort
                             select new
                             {
                                 a.LangName,
                                 ListenLevel = _XpCode.GetValue(c1, locale),
                                 SpeakLevel = _XpCode.GetValue(c2, locale),
                                 ReadLevel = _XpCode.GetValue(c3, locale),
                                 WriteLevel = _XpCode.GetValue(c4, locale),
                             })
                             .ToList();

            var userSkills = db.UserSkill
                .Where(a => a.UserId == userId)
                .Select(a => a)
                .ToList();
            #endregion

            //3.put rows into childs property(IEnumerable type !!)
            var childs = new List<dynamic>() 
            {
                userJobs, userSchools, userLicenses, 
                userLangs, userSkills
            };

            //4.prepare image list
            List<WordImageDto>? images = null;
            if (!string.IsNullOrEmpty(user!.PhotoFile))
                images =
                [
                    new() { Code = "Photo", FilePath = _Xp.PathUserExt(user.Id, _File.GetFileExt(user.PhotoFile)) }
                ];

            //5.call public method
            //if (!_HttpWord.OutputTplA2())
            if (!await _HttpWord.OutputTplA(tplPath, "UserExt.docx", user, childs, images))
                return false;

            //case of ok
            return true;

        lab_error:
            await _Log.ErrorRootA("UserExtService.cs GenWord() failed: " + error);
            return false;
        }

    }//class
}
