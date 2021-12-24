using HrAdm.Enums;
using HrAdm.Models;
using HrAdm.Services;
using Microsoft.Extensions.Localization;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class CmsMsgController : XpCmsController
    {
        //constructor, localization syntax
        public CmsMsgController(IStringLocalizer<CmsMsgController> R)
        {
            //ProgName = "最新消息維護";
            CmsType = CmsTypeEstr.Msg;
            DirUpload = _Xp.DirCmsType(CmsType);
            EditDto = new CmsEditDto()
            {
                Title = R["Title"].Value,
                Text = R["Text"].Value,
                //Html = "Html",
                Note = R["Note"].Value,
                FileName = R["FileName"].Value,
                StartTime = R["StartTime"].Value,
                EndTime = R["EndTime"].Value,
            };
        }

    }//class
}