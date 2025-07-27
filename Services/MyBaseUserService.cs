using Base.Interfaces;
using Base.Models;
using BaseApi.Services;

namespace HrAdm.Services
{
    public class MyBaseUserService : IBaseUserSvc
    {
        //get base user info
        public BaseUserDto GetData()
        {
            //return _Http.GetSession().Get<BaseUserDto>(_Fun.FidBaseUser)!;   //extension method
            return _Http.CookieToBr();
        }
    }
}
