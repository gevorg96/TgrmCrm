using System;
using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class Account: IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Tels { get; set; }
        public DateTime? sentDate { get; set; }
        public bool isActive { get; set; }
        public int Role { get; set; }
    }
}
