using System;

namespace TellRachel.Domain.Entities
{
    public interface IUserTimestamp
    {
        DateTime TakenDate { get; set; }
    }
}
