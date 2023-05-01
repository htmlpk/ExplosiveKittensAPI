using ExplosiveKittens.Data.Entities.Base;
using Redis.OM.Modeling;
using System;
using System.Collections.Generic;

namespace ExplosiveKittens.Data.Entities
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Deck" })]
    public class Deck : BaseEntity
    {
        [Searchable]
        public Guid GameId { get; set; }

        [Indexed(CascadeDepth = 1)]    
        public List<Card> Cards { get;set;}

    }
}
