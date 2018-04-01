
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
        public void Add(ToggleDtoCreate toggleDtoCreate)
        {
           Service service= unitOfWork.ServiceRepository.GetById(toggleDtoCreate.ServiceId);
            if (service==null)
            {
                throw new Exception("Not found service  :"+ toggleDtoCreate.ServiceId);
            }

            
            switch (toggleDtoCreate.TypeOfActionToogle )
            {
                case DTOS.TypeToggleDto.IsButtonBlue:
                    if (service.Name=="ABC" && toggleDtoCreate.State==false)
                    {
                        InsertToggle(toggleDtoCreate,service, "IsButtonBlue");
                    }
                  else  if (service.Name != "ABC" && toggleDtoCreate.State)
                    {
                        InsertToggle(toggleDtoCreate, service, "IsButtonBlue");
                    }
                    break;
                case DTOS.TypeToggleDto.IsButtonGreen:
                    if (service.Name == "ABC" && toggleDtoCreate.State)
                    {
                        InsertToggle(toggleDtoCreate, service, "IsButtonGreen");
                    }
                    else if (service.Name != "ABC" && toggleDtoCreate.State)
                    {
                        toggleDtoCreate.State = false;
                        InsertToggle(toggleDtoCreate, service, "IsButtonGreen");
                    }
                    break;
                case DTOS.TypeToggleDto.IsButtonRed:
                    if (service.Name != "ABC" && toggleDtoCreate.State)
                    {
                        InsertToggle(toggleDtoCreate, service, "IsButtonRed");
                    }
                    else if (toggleDtoCreate.State==false)
                    {
                        
                        InsertToggle(toggleDtoCreate, service, "IsButtonRed");
                    }
                    break;
                case DTOS.TypeToggleDto.None:
                    break;
                default:
                    break;
            }
            
        }

        private void InsertToggle(ToggleDtoCreate toggleDtoCreate,Service service,string name )
        {
            Toggle _toogle = new Toggle();
            _toogle.Identifier = Guid.NewGuid();
            
            _toogle.Services.Add(service);
            _toogle.Name = name;
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
