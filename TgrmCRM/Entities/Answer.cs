using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class Answer: IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Value { get; set; }
    }
}
