using Redis.OM.Modeling;
using System;

namespace ExplosiveKittens.Data.Entities.Base
{
    public class BaseEntity:IEntity
    {
        [RedisField]
        [Indexed]
        public Guid Id { get; set; }
        [Indexed]
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
