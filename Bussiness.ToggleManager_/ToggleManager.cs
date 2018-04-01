
using Bussiness.Dtos.ToggleManager;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Bussiness.ToggleManager
{
    public class ToggleManager : IToggleManager
    {
        private UnitOfWork unitOfWork = new UnitOfWork(); 
        public void Add(ToggleDtoCreate toogleDtoCreate)
        {
          Toggle _toogle=  new Toggle();
            _toogle.Identifier = Guid.NewGuid();
           // _toogle.Name= toogleDto
          Service _service = new Service();

           // _toogle.Services.Add()
            unitOfWork.ToggleRepository.Insert(_toogle);
           
            unitOfWork.Save();
        }

        public IEnumerable<ToggleDto> GetAll()
        {
            var toggles = unitOfWork.ToggleRepository.Get().ConvertAll<ToggleDto>(c=>new ToggleDto(c));
            
            return toggles;
        }

        public ToggleDto GetById(ToggleDto toogle)
        {
            var toggle = unitOfWork.ToggleRepository.GetById(toogle.Id);
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
