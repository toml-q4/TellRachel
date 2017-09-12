using System;
using System.ComponentModel.DataAnnotations;

namespace TellRachel.Models.Symptom
{
    public class SymptomCreationModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime TakenDate { get; set; }
    }
}
