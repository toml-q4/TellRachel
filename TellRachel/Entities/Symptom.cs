using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Entities
{
    public class Symptom : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public Guid? TemperatureId { get; set; }
        [ForeignKey("TemperatureId")]
        public Temperature Temperature { get; set; }

        #region FK - Note
        [Required]
        public Guid NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        #endregion
    }
}
