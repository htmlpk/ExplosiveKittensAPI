using ExplosiveKittens.Data.Entities.Base;
using ExplosiveKittens.Data.Enums;
using Redis.OM.Modeling;
using System;
using System.Collections.Generic;

namespace ExplosiveKittens.Data.Entities
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Gane" })]
    public class Game : BaseEntity
    {
        [Indexed]
        public GameType GameType { get; set; }  

        [Indexed(CascadeDepth = 1)]
        public List<Player> Players { get; set; }
    }
}
