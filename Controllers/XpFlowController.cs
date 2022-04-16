﻿using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using BaseWeb.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpFlowController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            await using(var db = new Db())
            {
                var locale0 = _Xp.GetLocale0();
                ViewBag.NodeTypes = await _XpCode.GetNodeTypesAsync(locale0, db);
                ViewBag.SignerTypes = await _XpCode.GetSignerTypesAsync(locale0, db);
                ViewBag.AndOrs = await _XpCode.GetAndOrsAsync(locale0, db);
                ViewBag.LineOps = await _XpCode.GetLineOpsAsync(locale0, db);
            }
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XgFlowRead().GetPageAsync(Ctrl, dt));
        }

        private XgFlowEdit EditService()
        {
            return new XgFlowEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateAsync(_Str.ToJson(json), FnSetNewKey));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateAsync(key, _Str.ToJson(json), FnSetNewKey));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteAsync(key));
        }

        /// <summary>
        /// delegate for setNewKey
        /// </summary>
        /// <param name="inputJson"></param>
        /// <param name="edit"></param>
        /// <returns></returns>
        private string FnSetNewKey(CrudEdit editService, JObject inputJson, EditDto edit)
        {
            var error = editService.SetNewKeyJson(inputJson, edit);
            if (_Str.NotEmpty(error))
                return error;

            error = editService.SetChildFkey(inputJson, 1, "StartNode", "00");
            if (_Str.NotEmpty(error))
                return error;

            return editService.SetChildFkey(inputJson, 1, "EndNode", "00");
        }

        //test flow
        //code: flow.Code
        //json: flow data in json string
        [HttpPost]
        public async Task<string> SaveFlowTest(string code, string data)
        {
            return await new TestFlowService().StartFlow(code, data);
        }

    } //class
}