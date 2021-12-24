namespace HrAdm.Models
{
    public class LoginVo
    {
        public string Account { get; set; }
        public string Pwd { get; set; }
        //public string Locale { get; set; }

        public string FromUrl { get; set; }

        public string AccountMsg { get; set; }
        public string PwdMsg { get; set; }
        public string ErrorMsg { get; set; }
    }
}