
using Data.Repositories;
using System.Collections.Generic;

namespace BussinesLayer.ToggleManager
{
    public class ToggleManager : IToggleManager
    {
        private UnitOfWork unitOfWork = new UnitOfWork(); 
        public void Add(ToggleDto toogle)
        {
            unitOfWork.ToggleRepository.Insert(new Toggle());
            unitOfWork.Save();
        }

        public IEnumerable<ToggleDto> GetAll()
        {
            var toggles = unitOfWork.ToggleRepository.Get(includeProperties: "Toggle");

            return null;
        }

        public ToggleDto GetById(ToggleDto toogle)
        {
            var toggle = unitOfWork.ToggleRepository.GetByID(toogle.Id);
            return new ToggleDto(toggle);
        }

        public ToggleDto Update(ToggleDto toogleDto)
        {
            unitOfWork.ToggleRepository.Update(new DataAccessLayer.Entities.Toggle());
            unitOfWork.Save();
            return toogleDto;
        }
    }
}
