using Base.Models;
using Base.Services;
using HrAdm.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    //for dropdown input
    public static class _XpCode
    {
        #region master table to codes
        public static async Task<List<IdStrDto>> GetProjectsAsync(Db db = null)
        {
            return await TableToListAsync("Project", db);
        }
        public static async Task<List<IdStrDto>> GetUsersAsync(Db db = null)
        {
            return await TableToListAsync("User", db);
        }
        public static async Task<List<IdStrDto>> GetDeptsAsync(Db db = null)
        {
            return await TableToListAsync("Dept", db);
        }
        public static async Task<List<IdStrDto>> GetRolesAsync(Db db = null)
        {
            return await TableToListAsync("XpRole", db);
        }

        /*
        public static async Task<List<IdStrDto>> GetProgsAsync(string locale0, Db db = null)
        {
            //return TableToList("XpProg", db);
            var sql = $@"
select 
    p.Id, (case when p.AuthRow=1 then '*' else '' end)+c.Name_{locale0} as Str
from dbo.XpProg p
join dbo.XpCode c on c.Type='Menu' and p.Code=c.Value
order by p.Sort";
            return await SqlToListAsync(sql, db);
        }
        */

        public static async Task<List<IdStrDto>> GetFlowsAsync(Db db = null)
        {
            return await TableToListAsync("XpFlow", db);
        }
        #endregion

        #region get from XpCode table
        public static async Task<List<IdStrDto>> GetAuthRangesAsync(string locale0, Db db = null)
        {
            return await TypeToListAsync(locale0, "AuthRange", db);
        }
        public static async Task<List<IdStrDto>> GetLangLevelsAsync(string locale0, Db db = null)
        {
            return await TypeToListAsync(locale0, "LangLevel", db);
        }
        public static async Task<List<IdStrDto>> GetLeaveTypesAsync(string locale0, Db db = null)
        {
            return await TypeToListAsync(locale0, "LeaveType", db);
        }
        //all xpCode rows
        public static async Task<List<IdStrDto>> GetSignStatusesAsync(string locale0, Db db = null)
        {
            return await TypeToListAsync(locale0, "SignStatus", db);
        }
        //ext=1 only for LeaveSign 
        public static async Task<List<IdStrDto>> GetSignStatuses2Async(string locale0, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale0} as Str
from dbo.XpCode
where Type='SignStatus'
and Ext='1'
order by Sort";
            return await SqlToListAsync(sql, db);
        }
        #endregion

        #region for flow
        public static async Task<List<IdStrDto>> GetNodeTypesAsync(string locale, Db db = null)
        {
            return await TypeToListAsync(locale, "NodeType", db);
        }
        public static async Task<List<IdStrDto>> GetSignerTypesAsync(string locale, Db db = null)
        {
            return await TypeToListAsync(locale, "SignerType", db);
        }
        public static async Task<List<IdStrDto>> GetAndOrsAsync(string locale, Db db = null)
        {
            return await TypeToListAsync(locale, "AndOr", db);
        }
        public static async Task<List<IdStrDto>> GetLineOpsAsync(string locale, Db db = null)
        {
            return await TypeToListAsync(locale, "LineOp", db);
        }

        /*
        public static List<IdStrDto> GetSignTypes()
        {
            return new List<IdStrDto>()
            {
                new IdStrDto(){ Id = "Y", Str = "同意" },
                new IdStrDto(){ Id = "N", Str = "不同意" },
            };
        }
        */
        #endregion

        #region others
        public static List<IdStrDto> GetSelects()
        {
            return new List<IdStrDto>(){
                new IdStrDto(){ Id="1", Str="Select1"},
                new IdStrDto(){ Id="2", Str="Select2"},
            };
        }
        public static List<IdStrDto> GetRadios()
        {
            return new List<IdStrDto>(){
                new IdStrDto(){ Id="1", Str="Radio1"},
                new IdStrDto(){ Id="2", Str="Radio2"},
            };
        }
        #endregion

        private static async Task<List<IdStrDto>> TableToListAsync(string table, Db db = null)
        {
            var sql = string.Format(@"
select 
    Id, [Name] as Str
from dbo.[{0}]
order by Id
", table);
            return await SqlToListAsync(sql, db);
        }

        //get codes from sql 
        private static async Task<List<IdStrDto>> SqlToListAsync(string sql, Db db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsAsync<IdStrDto>(sql);
            await _Fun.CheckCloseDb(db, emptyDb);
            return rows;
        }

        //get code table rows
        private static async Task<List<IdStrDto>> TypeToListAsync(string locale0, string type, Db db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale0} as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return await SqlToListAsync(sql, db);           
        }
        public static string GetValue(XpCode row, string locale)
        {
            var name = "Name_" + locale;
            //return _Linq.FnGetValue<XpCode>(name).ToString();
            return _Model.GetValue<XpCode>(row, name).ToString();
        }

        /*
        public static List<IdStrExtModel> GetCodeExts(string type, Db db = null)
        {
            var emptyDb = (db == null);
            if (emptyDb)
                db = new Db();

            var sql = string.Format(@"
select 
    Value as Id, Name as Str, Ext
from dbo.XpCode
where Type='{0}'
and Ext='0'
order by Sort
", type);
            var rows = db.GetModels<IdStrExtModel>(sql);
            if (emptyDb)
                db.Dispose();
            return rows;
        }
        */

    }//class
}
