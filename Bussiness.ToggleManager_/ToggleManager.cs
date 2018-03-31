
using Bussiness.Dtos.ToggleManager;
using Data.Entities;
using Data.Repositories;
using System.Collections.Generic;

namespace Bussiness.ToggleManager
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
            var toggles = unitOfWork.ToggleRepository.Get();

            return null;
        }

        public ToggleDto GetById(ToggleDto toogle)
        {
            var toggle = unitOfWork.ToggleRepository.GetByID(toogle.Id);
            return new ToggleDto(toggle);
        }

        public ToggleDto Update(ToggleDto toogleDto)
        {
            unitOfWork.ToggleRepository.Update(new Toggle());
            unitOfWork.Save();
            return toogleDto;
        }
    }
}
