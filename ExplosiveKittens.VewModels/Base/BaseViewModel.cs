using System;

namespace ExplosiveKittens.VewModels.Base
{
    public class BaseViewModel
    {

        public Guid Id;
        public DateTime CreatedDate;

        public BaseViewModel()
        {
            Id = Guid.NewGuid();
            CreatedDate = new DateTime();   
        }
    }
}
