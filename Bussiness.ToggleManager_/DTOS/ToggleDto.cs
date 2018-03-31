using Data.Entities;
using System;

namespace Bussiness.Dtos.ToggleManager
{
    public class ToggleDto
    {
      
        public Guid Id { get; set; }
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
