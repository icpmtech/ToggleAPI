using System;
using Bussiness.Dtos.ToggleManager;

namespace ToggleAPI.Models
{
    public class ServiceViewModel
    {
       

        public ServiceViewModel(ServiceDto service)
        {
            this.Id = service.Id;
            this.Version = service.Version;
            this.Name = service.Name;
        }

        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string Name { get; private set; }
    }
}