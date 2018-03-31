using Data.Entities;
using System;

namespace BussinesLayer.ToggleManager
{
    public class ToggleDto
    {
      
        public int Id { get; set; }
        public int Version { get; set; }
       
        private Toggle toggle;
      
        public ToggleDto()
        {
        }

        public ToggleDto(Toggle toggle)
        {
            this.toggle = toggle;
        }

       
    }
}
