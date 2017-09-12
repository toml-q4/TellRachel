﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TellRachel.Domain.Enums;

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

        public string Maker { get; set; }

        public string ProductOverview { get; set; }

        [Required]
        public string Dosage { get; set; }

        public string Ingredients { get; set; }

        public string Caution { get; set; }

        public string Warning { get; set; }

        public string PurchaseUrl { get; set; }

        public string ProductUrl { get; set; }
    }
}
