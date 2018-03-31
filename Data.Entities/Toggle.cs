using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Toggle
    {
        public Toggle()
        {
            Services = new HashSet<Service>();
        }
        [Key]
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Service> Services { get; set; }
       
    }
}
