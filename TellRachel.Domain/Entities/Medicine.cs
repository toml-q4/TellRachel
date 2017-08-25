using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Domain.Entities
{
    public class Medicine : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        #region FK - Note

        public Guid NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        #endregion
    }
}
