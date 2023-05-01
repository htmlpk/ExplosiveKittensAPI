using System;

namespace ExplosiveKittens.Data.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
