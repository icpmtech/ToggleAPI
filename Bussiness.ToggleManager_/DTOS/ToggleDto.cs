using Bussiness.ToggleManager.DTOS;
using Data.Entities;
using System;
using System.Collections.Generic;

namespace Bussiness.Dtos.ToggleManager
{
    public class ToggleDto
    {
      
        public Guid Id { get; set; }
        public ICollection<ServiceDto> ServicesDto { get; set; }
        public int Version { get; set; }
        public Guid ServiceId { get; set; }
        public TypeToggleDto TypeOfActionToogle { get; set; }
        public bool State { get; set; }

        private Toggle toggle;
      
        public ToggleDto()
        {

        }

        public ToggleDto(Toggle toggle)
        {
            this.ServicesDto = new List<ServiceDto>();
            this.Id = toggle.Identifier;
            if (toggle.Name== "IsButtonBlue")
            {
                this.TypeOfActionToogle = TypeToggleDto.IsButtonBlue;
            }
            else if (toggle.Name == "IsButtonRed")
            {
                this.TypeOfActionToogle = TypeToggleDto.IsButtonGreen;
            }
            else if(toggle.Name == "IsButtonGreen")
            {
                this.TypeOfActionToogle = TypeToggleDto.IsButtonRed;
            }

            foreach (var service in toggle.Services)
            {
                this.ServicesDto.Add(new ServiceDto(service));
            }
           
            
        }

       
    }
}
