using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Entities
{
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        #region FK - Note

        public int NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        #endregion
    }
}
