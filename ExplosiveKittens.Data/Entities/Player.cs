﻿using ExplosiveKittens.Data.Entities.Base;
using Redis.OM.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveKittens.Data.Entities
{
    public class Player:BaseEntity
    {
        [Indexed]
        public string Email { get; set; }
        [Indexed]
        public int Order { get; set; }
    }
}
