﻿using Base.Services;
using BaseApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAdm.Services
{
    public class TestFlowService
    {
        public async Task<string> StartFlow(string flowCode, string inputJson)
        {
            //check input
            var row = _Str.ToJson("{" + inputJson + "}");
            if (row == null)
                return "輸入資料的格式不正確。";

            //set value of user fid
            var userFid = "UserId";
            if (row[userFid] == null)
                return "UserId 欄位不可空白。";

            //create signed rows first
            var userId = row[userFid]!.ToString();
            var newId = _Str.NewId();
            await using var db = new Db();
            await db.BeginTranA();
            var error = await _XgFlow.CreateSignRowsA(row, userFid, flowCode, newId, true, db);

            //create source row
            if (string.IsNullOrEmpty(error))
            {
                var sql = @"
insert into dbo.XpTestFlowSource(Id, InputJson, UserId, Created, FlowLevel, FlowStatus) 
values (@Id, @InputJson, @UserId, @Created, 1, '0')";

                var args = new List<Object>()
                {
                    "Id", newId,
                    "InputJson", inputJson,
                    "UserId", userId,
                    "Created", DateTime.Now,
                };
                await db.ExecSqlA(sql, args);
            }

            if (string.IsNullOrEmpty(error))
                await db.CommitA();
            else
                await db.RollbackA();

            return error;
        }

    }//class
}
