using Data.Entities;
using System;

namespace Bussiness.Dtos.ToggleManager
{
    public class ToggleDtoCreate
    {
      
        public Guid Id { get; set; }
        public int Version { get; set; }
        public Guid ServiceId { get; set; }
        public bool State { get; set; }
        public int TypeOfActionToogle { get; set; }
    }
}
