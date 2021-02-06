using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
