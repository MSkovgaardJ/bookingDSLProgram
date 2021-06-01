using System;
using System.Collections.Generic;

namespace DangleterreV2.Persistence.Models
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
