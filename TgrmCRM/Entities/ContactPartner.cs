using System.ComponentModel.DataAnnotations;


namespace TgrmCRM.Entities
{
    public class ContactPartner: IEntity
    {
        [Key]
        public long Id { get; set; }

        public Partner Partner { get; set; }
        public Contact Contact { get; set; }
    }
}
