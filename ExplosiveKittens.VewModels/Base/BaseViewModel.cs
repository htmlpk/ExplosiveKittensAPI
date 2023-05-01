using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveKittens.VewModels.Base
{
    public class BaseViewModel
    {

        public Guid Id;
        public DateTime CreatedDate;

        public BaseViewModel()
        {
            Id = new Guid();
            CreatedDate = new DateTime();   
        }
    }
}
