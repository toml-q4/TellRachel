using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TellRachel.Domain.Entities
{
    public class Note : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateUtc { get; set; }

        public ICollection<Symptom> Symptoms { get; set; }

        public ICollection<MedicineDose> MedicineDoses { get; set; }
    }
}
