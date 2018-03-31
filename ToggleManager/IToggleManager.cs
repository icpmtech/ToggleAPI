
using System.Collections.Generic;

namespace BussinesLayer.ToggleManager
{
    public interface IToggleManager
    {
        void Add(ToggleDto toogleDto);
        ToggleDto GetById(ToggleDto toogleDto);
        ToggleDto Update(ToggleDto toogleDto);
        IEnumerable<ToggleDto> GetAll();
    }
}