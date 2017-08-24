using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Entities
{
    public class Temperature : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public bool IsFahrenheit { get; set; }

        #region FK - Note
        [Required]
        public Guid NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }
        #endregion
    }
}
