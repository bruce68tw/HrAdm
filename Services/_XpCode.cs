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
        public static async Task<List<IdStrDto>?> ProjectsA(Db? db = null)
        {
            return await _Db.TableToCodesA("Project", db);
        }
        public static async Task<List<IdStrDto>?> UsersA(Db? db = null)
        {
            return await _Db.TableToCodesA("XpUser", db);
        }
        public static async Task<List<IdStrDto>?> DeptsA(Db? db = null)
        {
            return await _Db.TableToCodesA("XpDept", db);
        }
        public static async Task<List<IdStrDto>?> RolesA(Db? db = null)
        {
            return await _Db.TableToCodesA("XpRole", db);
        }

        /*
        public static async Task<List<IdStrDto>> GetProgsA(string locale0, Db? db = null)
        {
            //return TableToList("XpProg", db);
            var sql = $@"
select 
    p.Id, (case when p.AuthRow=1 then '*' else '' end)+c.Name_{locale0} as Str
from dbo.XpProg p
join dbo.XpCode c on c.Type='Menu' and p.Code=c.Value
order by p.Sort";
            return await SqlToListA(sql, db);
        }
        */

        public static async Task<List<IdStrDto>?> FlowsA(Db? db = null)
        {
            return await _Db.TableToCodesA("XpFlow", db);
        }
        #endregion

        #region get from XpCode table
        public static async Task<List<IdStrDto>?> LineFromTypesA(string locale0, Db? db = null)
        {
            return await _Db.TypeToCodesA("LineFromType", db, locale0);
        }
        public static async Task<List<IdStrDto>?> AuthRangesA(string locale0, Db? db = null)
        {
            return await _Db.TypeToCodesA("AuthRange", db, locale0);
        }
        public static async Task<List<IdStrDto>?> LangLevelsA(string locale0, Db? db = null)
        {
            return await _Db.TypeToCodesA("LangLevel", db, locale0);
        }
        public static async Task<List<IdStrDto>?> LeaveTypesA(string locale0, Db? db = null)
        {
            return await _Db.TypeToCodesA("LeaveType", db, locale0);
        }
        //all xpCode rows
        public static async Task<List<IdStrDto>?> FlowStatusesA(string locale0, Db? db = null)
        {
            return await _Db.TypeToCodesA("FlowStatus", db, locale0);
        }
        public static async Task<List<IdStrDto>?> SignStatusesA(string locale0, Db? db = null)
        {
            return await _Db.TypeToCodesA("SignStatus", db, locale0);
        }
        //ext=1 only for FlowSign Form
        public static async Task<List<IdStrDto>?> SignStatuses2A(string locale0, Db? db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale0} as Str
from dbo.XpCode
where Type='SignStatus'
and Ext='1'
order by Sort";
            return await _Db.SqlToCodesA(sql, null, db);
        }
        #endregion

        #region for flow
        public static async Task<List<IdStrDto>?> NodeTypesA(string locale, Db? db = null)
        {
            return await _Db.TypeToCodesA("NodeType", db, locale);
        }
        public static async Task<List<IdStrDto>?> SignerTypesA(string locale, Db? db = null)
        {
            return await _Db.TypeToCodesA("SignerType", db, locale);
        }
        public static async Task<List<IdStrDto>?> AndOrsA(string locale, Db? db = null)
        {
            return await _Db.TypeToCodesA("AndOr", db, locale);
        }
        public static async Task<List<IdStrDto>?> LineOpsA(string locale, Db? db = null)
        {
            return await _Db.TypeToCodesA("LineOp", db, locale);
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

        /*
        private static async Task<List<IdStrDto>> TableToListA(string table, Db? db = null)
        {
            var sql = string.Format(@"
select 
    Id, [Name] as Str
from dbo.[{0}]
order by Id
", table);
            return await SqlToListA(sql, db);
        }

        //get codes from sql 
        private static async Task<List<IdStrDto>> SqlToListA(string sql, Db? db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsA<IdStrDto>(sql);
            await _Fun.CheckCloseDbA(db, emptyDb);
            return rows;
        }

        //get code table rows
        private static async Task<List<IdStrDto>> TypeToListA(string locale0, string type, Db? db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale0} as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return await SqlToListA(sql, db);           
        }
        */

        public static string GetValue(XpCode row, string locale)
        {
            var name = "Name_" + locale;
            //return _Linq.FnGetValue<XpCode>(name).ToString();
            return _Model.GetValue<XpCode>(row, name)!.ToString()!;
        }

        /*
        public static List<IdStrExtModel> GetCodeExts(string type, Db? db = null)
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
