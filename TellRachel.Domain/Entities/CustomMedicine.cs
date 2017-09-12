using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TellRachel.Domain.Entities
{
    public class CustomMedicine : Medicine
    {
        #region FK - CommonMedicine

        public Guid CommonMedicineId { get; set; }
        [ForeignKey("CommonMedicineId")]
        public Medicine CommonMedicine { get; set; }

        #endregion

        #region FK - Note

        public Guid NoteId { get; set; }
        [ForeignKey("NoteId")]
        public Note Note { get; set; }

        #endregion

    }
}
