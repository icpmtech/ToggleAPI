using System;
using System.Collections.Generic;
using Bussiness.Dtos.ToggleManager;
using Bussiness.ToggleManager;

namespace Presentation.ClientToggle
{
    public class ClientToggle : IClientToggle
    {
       private IToggleManager _toggleManager;
        public ClientToggle(ToggleManager toggleManager)
        {
            _toggleManager = toggleManager;
        }
        public void Add(ToggleDto toogle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToggleDto> GetAll()
        {
            throw new NotImplementedException();
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
