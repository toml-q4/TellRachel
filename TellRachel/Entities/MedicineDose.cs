using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Entities
{
    public class MedicineDose : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [MaxLength(16)]
        public string Unit { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }

        #region Medicine

        [Required]
        public Guid MedicineId { get; set; }

        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }

        #endregion
    }
}
