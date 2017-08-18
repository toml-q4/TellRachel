using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Entities
{
    public class Note : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public DateTime? Birthday { get; set; }

        public int? WeightInGrams { get; set; }

        public bool? IsMale { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }

        public ICollection<Symptom> Symptoms { get; set; }

        public ICollection<MedicineDose> MedicineDoses { get; set; }
    }
}
