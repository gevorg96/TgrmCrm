using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class Account: IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Tels { get; set; }
    }
}
