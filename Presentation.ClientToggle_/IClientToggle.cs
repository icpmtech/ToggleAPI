
using Bussiness.Dtos.ToggleManager;
using System.Collections.Generic;

namespace Presentation.ClientToggle
{
    public interface IClientToggle
    {
        void Add(ToggleDto toogle);
        ToggleDto GetById(ToggleDto toogle);
        IEnumerable<ToggleDto> GetAll();
        ToggleDto Update(ToggleDto toogleDto);
    }
}