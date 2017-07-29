using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    new SymptomRecord
                    {
                        Id = 1,
                        Description = "Crying. Angry"
                    },
                    new MedicineRecord
                    {
                        Id = 2,
                        Description
                    }
                };
            }
        }
    }
}
