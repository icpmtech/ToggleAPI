using Data.Entities;
using System.Collections.Generic;

namespace Bussiness.Dtos.ToggleManager
{
    public class TogglesServiceDto
    {
        
        public ServiceDto ServiceDto { get; set; }
        public List< ToggleDto> TogglesDtos { get; set; }
        public TogglesServiceDto(Service service)
        {
            TogglesDtos = new List<ToggleDto>();
            foreach (var toggle in service.Toggles)
            {
                TogglesDtos.Add(new ToggleDto(toggle));
            }
            ServiceDto = new ServiceDto();
            this.ServiceDto.Id = service.Identifier;
            this.ServiceDto.Name = service.Name;
            this.ServiceDto.Version = service.Version;
        }
    }
}