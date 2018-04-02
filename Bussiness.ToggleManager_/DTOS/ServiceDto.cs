using Bussiness.ToggleManager.DTOS;
using Data.Entities;
using System;
using System.Collections.Generic;

namespace Bussiness.Dtos.ToggleManager
{
    public class ServiceDto
    {

        public ServiceDto()
        {
        }

        public ServiceDto(Service service)
        {
            this.Name = service.Name;
            this.Id = service.Identifier;
            this.Version= service.Version;
            
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public int Version { get; set; }
    }
}
