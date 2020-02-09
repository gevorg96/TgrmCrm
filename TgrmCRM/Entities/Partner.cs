using System.ComponentModel.DataAnnotations;

namespace TgrmCRM.Entities
{
    public class Partner: IEntity
    {
        [Key]
        public long Id { get; set; }
        public string PartnerName { get; set; }
        public string DecisionMaker { get; set; }
        public string Tel { get; set; }
    }
}
