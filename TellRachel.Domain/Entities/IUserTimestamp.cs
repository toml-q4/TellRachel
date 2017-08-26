using System;
using System.Collections.Generic;
using System.Text;

namespace TellRachel.Domain.Entities
{
    public interface IUserTimestamp
    {
        DateTime TakenDate { get; set; }
    }
}
