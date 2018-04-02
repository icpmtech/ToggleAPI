
using Bussiness.Dtos.ToggleManager;
using System.Collections.Generic;

namespace Service.ClientToggle
{
    public interface IClientToggle
    {
       
        ToggleDto GetById(ToggleDto toogleDto);
        IEnumerable<ToggleDto> GetAll();
        ToggleDto Update(ToggleDto toogleDto);
        void Delete(ToggleDto toogleDto);
        void Add(ToggleDtoCreate toogleDtoCreate);
        TogglesServiceDto GetTogglesServiceByIdAndVersion(ServiceDto serviceDto);
    }
}