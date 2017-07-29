using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TellRachel.Enums;

namespace TellRachel.Entities
{
    public class HerRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public double Amount { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        [Required]
        public RecordType RecordType { get; set; }

        public int HerNoteId { get; set; }

        [ForeignKey("HerNoteId")]
        public HerNote HerNote { get; set; }
    }
}
