using Base.Models;
using Base.Services;

namespace HrAdm.Services
{
    public class XpFlowTestEdit : BaseEditSvc
    {
        private string _flowCode;   //XpFlow.Code
        public XpFlowTestEdit(string ctrl, string flowCode) : base(ctrl) 
        {
            _flowCode = flowCode;
        }

        override public EditDto GetDto()
        {
            //var locale = _Xp.GetLocale0();
            var sql = $@"
select
    d.*,
	s.Id as SignId,
    FlowStatusName=c.Name_zhTW,
    UserName=u.Name
from dbo.XpFlowSignTest s
join dbo.XpFlowTest d on s.SourceId=d.Id and s.FlowLevel=d.FlowLevel
join dbo.XpUser u on d.UserId=u.Id
join dbo.XpCode c on c.Type='FlowStatus' and d.FlowStatus=c.Value
where d.Id=@Id
";
            return new EditDto() { ReadSql = sql };
        }

    } //class
}
