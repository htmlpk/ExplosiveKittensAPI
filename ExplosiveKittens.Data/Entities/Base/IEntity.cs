using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveKittens.Data.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
    }
}
