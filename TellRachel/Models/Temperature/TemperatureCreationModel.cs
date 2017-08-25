namespace TellRachel.Models.Temperature
{
    public class TemperatureCreationModel
    {
        public double Value { get; set; }

        public bool IsFahrenheit { get; set; }

        public int NoteId { get; set; }
    }
}
