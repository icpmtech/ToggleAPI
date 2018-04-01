using System;
using System.Collections.Generic;
using Bussiness.Dtos.ToggleManager;
using Bussiness.ToggleManager;

namespace Service.ClientToggle
{
    public class ClientToggle : IClientToggle
    {
       private IToggleManager _toggleManager;
        public ClientToggle(IToggleManager toggleManager)
        {
            _toggleManager = toggleManager;
        }
       

        public void Add(ToggleDtoCreate toogleDtoCreate)
        {
            _toggleManager.Add(toogleDtoCreate);
        }

        public void Delete(ToggleDto toogleDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToggleDto> GetAll()
        {
          return  _toggleManager.GetAll();
        }

        public ToggleDto GetById(ToggleDto toogleDto)
        {
          return  _toggleManager.GetById(toogleDto);
        }

        public ToggleDto Update(ToggleDto toogleDto)
        {
           return _toggleManager.Update(toogleDto);
        }
    }
}
