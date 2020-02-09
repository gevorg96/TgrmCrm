using System;
using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class Contact: IEntity
    {
        [Key]
        public long Id { get; set; }

        public long TgrmId { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
