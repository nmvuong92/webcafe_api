
using VD.Data.Entity;
namespace Web.Areas.Admin.ViewModels
{
    public class Input
    {
        public int Id { get; set; }
    }
    public class LangInput
    {
        public LangInput()
        {
            this.IsExistsTrans = false;
        }
        public int Id { get; set; }
        public bool IsExistsTrans { get; set; }
        public int IsAllLanguage { get; set; }
    }
    public class TransInput
    {
        public int Id { get; set; }
        public int LangId { get; set; }
        public Lang LangEntity { get; set; }
    }
}