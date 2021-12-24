using Microsoft.Extensions.Localization;

namespace HrAdm
{
    //must be under root
    public class R0
    {
        private readonly IStringLocalizer _localizer;

        public R0(IStringLocalizer<R0> localizer)
        {
            _localizer = localizer;
        }
    }
}
