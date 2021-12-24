using Base.Models;
using Base.Services;
using BaseApi.Services;
using BaseWeb.Extensions;

namespace HrAdm.Services
{
    public class MyBaseUserService : IBaseUserService
    {
        //get base user info
        public BaseUserDto GetData()
        {
            return _Http.GetSession().Get<BaseUserDto>(_Fun.BaseUser);   //extension method
        }
    }
}
