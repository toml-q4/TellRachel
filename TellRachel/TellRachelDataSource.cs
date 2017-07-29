using System.Collections.Generic;
using TellRachel.Models;

namespace TellRachel
{
    public static class TellRachelDataSource
    {
        public IEnumerable<Record> Records
        {
            get
            {
                var recordList = new List<Record>()
                {
                    new RecordSymptom
                    {
                        Id = 1,
                        Description = "Crying. Angry"
                    },
                    new RecordMedicine
                    {
                        Id = 2,
                        Description
                    }
                };
            }
        }
    }
}
