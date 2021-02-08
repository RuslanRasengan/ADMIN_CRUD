using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Entities
{
    public class Image : BaseEntity
    {
        public string Src { get; set; }
        public string Name { get; set; }
        public virtual Product Product { get; set; }
    }
}
