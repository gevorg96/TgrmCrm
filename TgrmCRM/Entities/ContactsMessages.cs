using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class ContactsMessages: IEntity
    {
        [Key]
        public long Id { get; set; }

        public Contact Contact { get; set; }
        public ThemeMessage Message { get; set; }
        public bool IsAccepted { get; set; }
    }
}
