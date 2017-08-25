using System;

namespace TellRachel.Domain.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}
