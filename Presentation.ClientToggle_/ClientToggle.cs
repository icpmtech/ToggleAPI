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
        public void Add(ToggleDto toogle)
        {
            throw new NotImplementedException();
        }

        public void Delete(ToggleDto toggleDtoToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToggleDto> GetAll()
        {
          return  _toggleManager.GetAll();
        }

        public ToggleDto GetById(ToggleDto toogle)
        {
            throw new NotImplementedException();
        }

        public ToggleDto Update(ToggleDto toogleDto)
        {
            throw new NotImplementedException();
        }
    }
}
