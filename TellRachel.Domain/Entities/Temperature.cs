using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Domain.Entities
{
    public class Temperature : IEntityBase, IUserTimestamp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public bool IsFahrenheit { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }

        #region FK - Note
        [Required]
        public Guid NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }
        #endregion
    }
}
