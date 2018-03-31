using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToggleAPI.Models
{
    public class State
    {
        [Key]
        public Guid Identifier { get; set; }
        public enum Status { Blue,Green,Red }

        public virtual Service Service { get; set; }
        [ForeignKey("Service")]
        public Guid IdService { get; set; }
    }
}