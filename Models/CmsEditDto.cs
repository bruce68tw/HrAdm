namespace HrAdm.Models
{
    //control field visible or not
    public class CmsEditDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
        public string Note { get; set; }
        public string FileName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}