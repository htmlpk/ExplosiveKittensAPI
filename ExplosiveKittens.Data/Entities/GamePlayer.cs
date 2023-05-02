using Redis.OM.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveKittens.Data.Entities
{
    public class GamePlayer
    {
        [Indexed]
        public Guid GameId { get; set; }

        [Indexed(CascadeDepth = 1)]
        public List<Player> Players { get; set; }
    }
}
