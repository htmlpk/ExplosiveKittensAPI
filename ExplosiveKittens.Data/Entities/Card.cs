using ExplosiveKittens.Data.Enums;
using System;
using Redis.OM.Modeling;
using ExplosiveKittens.Data.Entities.Base;

namespace ExplosiveKittens.Data.Entities
{
    public class Card : BaseEntity
    {

        [Indexed]
        public KittenType Type { get; set; }
        [Indexed]
        public int Order { get; set; }

    }
}
