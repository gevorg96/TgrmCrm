using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class KeyAnswer
    {
        [Key]
        public long Id { get; set; }
        public bool IsPositive { get; set; }
        public ThemeMessage Message { get; set; }
        public string Keyword { get; set; }
    }
}
