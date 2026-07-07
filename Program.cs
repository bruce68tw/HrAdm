using Base.Enums;
using Base.Interfaces;
using Base.Models;
using Base.Services;
using BaseApi.Services;
using BaseWeb.Services;
using HrAdm.Services;
using System.Data.Common;
using System.Data.SqlClient;

#region set builder
var builder = WebApplication.CreateBuilder(args);

//6.appSettings "FunConfig" section -> _Fun.Config
var config = new ConfigDto();
builder.Configuration.GetSection("FunConfig").Bind(config);
_Fun.Config = config;

builder.SetBuilder();
#endregion

#region set services
var multiLang = true;
var services = builder.Services;
services.SetServices(multiLang);

services.AddSingleton<IBaseUserSvc, MyBaseUserService>();   //user info for base component
services.AddTransient<DbConnection, SqlConnection>();   //ado.net for mssql
services.AddTransient<DbCommand, SqlCommand>();

//cache server
services.AddMemoryCache();
services.AddSingleton<ICacheSvc, CacheMemSvc>();
#endregion

#region set app
var app = builder.Build();
var isDev = app.Environment.IsDevelopment();
_Fun.Init(isDev, app.Services, DbTypeEnum.MSSql, AuthTypeEnum.Row, multiLang);
await _Locale.SetCultureA(_Fun.Config.Locale);

app.SetApp(isDev);
app.Run();
#endregion