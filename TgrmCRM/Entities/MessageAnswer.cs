using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TgrmCRM.Entities
{
    public class MessageAnswer: IEntity
    {
        [Key]
        public long Id { get; set; }
        public Answer Answer { get; set; }
        public ThemeMessage Message { get; set; }
    }
}
