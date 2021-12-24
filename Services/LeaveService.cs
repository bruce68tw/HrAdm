using Base.Services;
using HrAdm.Models;
using System.Collections.Generic;
using System.Linq;

namespace HrAdm.Services
{
    public class LeaveService
    {
        public List<SignRowDto> GetSignRows(string id)
        {
            var locale = _Xp.GetLocale0();
            var db = _Xp.GetDb();
            return (from s in db.XpFlowSign
                    join f in db.XpFlow on s.FlowId equals f.Id
                    join c in db.XpCode on new { Type = "SignStatus", Value = s.SignStatus } 
                        equals new { c.Type, c.Value }
                    where (f.Code == "Leave" && s.SourceId == id)
                    orderby s.FlowLevel
                    select new SignRowDto()
                    {
                        NodeName = s.NodeName,
                        SignerName = s.SignerName,
                        SignStatusName = _XpCode.GetValue(c, locale),
                        SignTime = (s.SignTime == null) 
                            ? "" : s.SignTime.Value.ToString(_Fun.CsDtFmt),
                        Note = s.Note,
                    })
                    .ToList();
        }

    } //class
}