using Base.Models;
using Base.Services;
using BaseWeb.Services;
using HrAdm.Enums;
using HrAdm.Models;
using HrAdm.Tables;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class UserImportService
    {
        /// <summary>
        /// import excel file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>ResultImportDto</returns>
        public async Task<ResultImportDto> ImportAsync(IFormFile file, string dirUpload)
        {
            var importDto = new ExcelImportDto<UserImportVo>()
            {
                ImportType = ImportTypeEstr.User,
                TplPath = _Xp.DirTpl + "UserImport.xlsx",
                FnSaveImportRows = SaveImportRows,
                CreatorName = _Fun.GetBaseUser().UserName,
            };
            return await _WebExcel.ImportByFileAsync(file, dirUpload, importDto);
        }

        /// <summary>
        /// check & save DB
        /// </summary>
        /// <param name="okRows"></param>
        /// <returns>list error/empty </returns>
        private List<string> SaveImportRows(List<UserImportVo> okRows)
        {
            var db = _Xp.GetDb();
            var deptIds = db.Dept.Select(a => a.Id).ToList();
            var results = new List<string>();
            foreach (var row in okRows)
            {
                //check rules: deptId
                if (!deptIds.Contains(row.DeptId))
                {
                    results.Add("DeptId Wrong.");
                    continue;
                }

                //check rules: Account not repeat
                if (db.User.Any(a => a.Account == row.Account))
                {
                    results.Add("Account Existed.");
                    continue;
                }

                #region set entity model & save db
                db.User.Add(new User() { 
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
                    results.Add("");
                }
                catch (Exception ex)
                {
                    results.Add(ex.InnerException.Message);
                }
                #endregion
            }
            return results;
        }
    } //class
}