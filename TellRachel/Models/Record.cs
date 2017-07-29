using System;
using TellRachel.Enums;

namespace TellRachel.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public MeasureUnit Unit { get; set; }
    }
}
