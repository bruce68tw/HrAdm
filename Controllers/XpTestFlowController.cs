﻿using Base.Enums;
using Base.Models;
using Base.Services;
using BaseApi.Attributes;
using BaseApi.Controllers;
using BaseApi.Services;
using HrAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdm.Controllers
{
    [XgProgAuth]
    public class XpTestFlowController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            //for read view
            var locale0 = _Xp.GetLocale0();
            await using var db = new Db();
            ViewBag.Flows = await _XpCode.FlowsA(db);
			ViewBag.FlowStatuses = await _XpCode.FlowStatusesA(locale0, db);
			//for edit view
            ViewBag.SignStatuses2 = await _XpCode.SignStatuses2A(locale0, db);
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new XpTestFlowRead().GetPageA(Ctrl, dt));
        }

        private XpTestFlowEdit EditService(string flowCode)
        {
            return new XpTestFlowEdit(Ctrl, flowCode);
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<ContentResult> GetUpdJson(string flowCode, string key)
        {
            return JsonToCnt(await EditService(flowCode).GetUpdJsonA(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public async Task<ContentResult> GetViewJson(string flowCode, string key)
        {
            return JsonToCnt(await EditService(flowCode).GetViewJsonA(key));
        }

        /// <summary>
        /// get signRows partial view
        /// </summary>
        /// <param name="id">XpTestFlowSource.Id</param>
        /// <returns></returns>
        public ActionResult GetSignRows(string id)
        {
            return PartialView(_Xp.SignRowsView, new XpTestFlowService().GetSignRows(id));
        }

        [HttpPost]
        public async Task<JsonResult> SignRow(string id, string status, string note)
        {
            return Json(await _XgFlow.SignRowA(id, (status == "Y"), note, "XpTestFlowSource", true, FlowBackTypeEnum.Close));
        }

    }//class
}