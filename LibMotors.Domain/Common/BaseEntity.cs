using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotors.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
      
    }
}
