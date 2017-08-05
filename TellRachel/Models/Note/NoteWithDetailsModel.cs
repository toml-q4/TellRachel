using System.Collections.Generic;
using TellRachel.Models.Medicine;
using TellRachel.Models.Symptom;

namespace TellRachel.Models.Note
{
    public class NoteWithDetailsModel : NoteModel
    {
        public ICollection<MedicineDoseCreationModel> MedicineDoses { get; set; } = new List<MedicineDoseCreationModel>();
        public ICollection<SymptomModel> Symptoms { get; set; } = new List<SymptomModel>();
    }
}
