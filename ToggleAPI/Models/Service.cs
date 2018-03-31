using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToggleAPI.Models
{
    public class Service
    {
        [Key]
        public Guid Identifier { get; set; }
        public int Version { get; set; }
        public  virtual State State { get; set; }
    }
}