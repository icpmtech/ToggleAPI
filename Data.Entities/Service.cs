using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Service
    {
        public Service()
        {
            this.Toggles = new HashSet<Toggle>();
        }
        [Key]
        public Guid Identifier { get; set; }
        public int Version { get; set; }
        public virtual ICollection<Toggle> Toggles { get; set; }
        public string Name { get; set; }
    }
}