using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class ThemeMessage: IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Body { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
