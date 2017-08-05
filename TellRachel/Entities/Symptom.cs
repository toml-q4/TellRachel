using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Entities
{
    public class Symptom : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double TemperatureInCelsius { get; set; }

        #region FK - Note

        public int NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        #endregion
    }
}
