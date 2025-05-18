using Base.Models;
using Base.Services;
using BaseApi.Services;
using HrAdm.Enums;
using HrAdm.Models;
using HrAdm.Tables;

namespace HrAdm.Services
{
    public class UserImportService
    {
        /// <summary>
        /// import excel file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>ResultImportDto</returns>
        public async Task<ResultImportDto> ImportA(IFormFile file, string dirUpload)
        {
            var importDto = new ExcelImportDto<UserImportVo>()
            {
                ImportType = ImportTypeEstr.User,
                TplPath = _Xp.DirTpl + "UserImport.xlsx",
                FnSaveImportRows = FnSaveImportRows,
                CreatorName = _Fun.GetBaseUser().UserName,
            };
            return await _HttpExcel.ImportByFileA(file, dirUpload, importDto);
        }

        /// <summary>
        /// check & save DB
        /// </summary>
        /// <param name="okRows"></param>
        /// <returns>list error/empty, 對應okRows </returns>
        private List<string> FnSaveImportRows(List<UserImportVo> okRows)
        {
            var db = _Xp.GetDb();
            var deptIds = db.XpDept.Select(a => a.Id).ToList();
            var errors = new List<string>();
            foreach (var row in okRows)
            {
                //check rules: deptId
                if (!deptIds.Contains(row.DeptId))
                {
                    errors.Add("DeptId Wrong.");
                    continue;
                }

                //check rules: Account not repeat
                if (db.XpUser.Any(a => a.Account == row.Account))
                {
                    errors.Add("Account Existed.");
                    continue;
                }

                #region set entity model & save db
                db.XpUser.Add(new XpUser() { 
                    Id = _Str.NewId(),
                    Name = row.Name,
                    Account = row.Account,
                    Pwd = row.Pwd,
                    DeptId = row.DeptId,
                    Status = true,
                });

                //save db
                try
                {
                    db.SaveChanges();
                    errors.Add("");
                }
                catch (Exception ex)
                {
                    errors.Add(ex.InnerException!.Message);
                }
                #endregion
            }
            return errors;
        }
    } //class
}