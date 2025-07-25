﻿using Base.Models;
using Base.Services;
using BaseApi.Attributes;
using BaseApi.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrAdmin.Controllers
{
    public class HomeController : Controller
    {
        private bool encodePwd = false;

        [XgLogin]
        public ActionResult Index()
        {
            return View();
        }

        //called by XgLogin
        public ActionResult Login(string url = "")
        {
            return View(new LoginVo() { FromUrl = url });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVo vo)
        {
            return await _Login.LoginByVoA(vo, "", encodePwd)
                ? Redirect(_Str.IsEmpty(vo.FromUrl) ? "/Home/Index" : vo.FromUrl)
                : View(vo);

            /*
            #region 1.check input account & password
            //reset UI msg
            vo.AccountMsg = "";
            vo.PwdMsg = "";

            if (_Str.IsEmpty(vo.Account))
            {
                vo.AccountMsg = "field is required.";
                goto lab_exit;
            }
            if (_Str.IsEmpty(vo.Pwd))
            {
                vo.PwdMsg = "field is required.";
                goto lab_exit;
            }
            #endregion

            #region 2.check DB password & get user info
            var sql = @"
select u.Id as UserId, u.Name as UserName, u.Pwd,
    u.DeptId, d.Name as DeptName
from dbo.XpUser u
join dbo.XpDept d on u.DeptId=d.Id
where u.Account=@Account
";
            var row = await _Db.GetRowA(sql, new List<object>() { "Account", vo.Account });
            //TODO: encode if need
            //if (row == null || row["Pwd"].ToString() != _Str.Md5(vo.Pwd))
            if (row == null || row["Pwd"]!.ToString() != vo.Pwd)
            {
                vo.AccountMsg = "input wrong.";
                goto lab_exit;
            }
            #endregion

            #region 3.set base user info
            var userId = row["UserId"]!.ToString();
            var userInfo = new BaseUserDto()
            {
                UserId = userId,
                UserName = row["UserName"]!.ToString(),
                DeptId = row["DeptId"]!.ToString(),
                DeptName = row["DeptName"]!.ToString(),
                Locale = _Fun.Config.Locale,
                ProgAuthStrs = await _Auth.GetAuthStrsA(userId),
                //IsLogin = true,
            };
            #endregion

            //4.set session of base user info
            _Http.GetSession().Set(_Fun.FidBaseUser, userInfo);   //extension method

            //5.redirect if need
            var url = _Str.IsEmpty(vo.FromUrl) ? "/Home/Index" : vo.FromUrl;
            return Redirect(url);

        lab_exit:
            return View(vo);
            */
        }

        public ActionResult Logout()
        {
            _Http.DeleteCookie(_Fun.FidClientKey);
            return Redirect("/Home/Login");
        }

        public ActionResult Error()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("Error", (error == null) ? _Fun.SystemError : error.Error.Message);
        }

        /*
        public string SetLocale(string locale)
        {
            _Locale.SetCulture(locale);
            return locale;
        }
        */
    }
}