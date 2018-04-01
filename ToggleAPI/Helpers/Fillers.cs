using Bussiness.Dtos.ToggleManager;
using System;
using ToggleAPI.Models;

namespace ToggleAPI.Helpers
{
    /// <summary>
    /// Class Helper to fill Dtos
    /// </summary>
    public static class Fillers
    {
        /// <summary>
        /// Fill one modelviewcreate to an ToggleDtoCreate.
        /// </summary>
        /// <param name="toggleViewModelCreate"> UI model view.</param>
        /// <returns> An ToggleDtoCreate filled. </returns>
        public static ToggleDtoCreate FillToggleDtoCreate(ToggleViewModelCreate toggleViewModelCreate)
        {
            ToggleDtoCreate toogleDtoCreate = new ToggleDtoCreate();
           
            toogleDtoCreate.Version = toggleViewModelCreate.Version;
            toogleDtoCreate.ServiceId = toggleViewModelCreate.ServiceId;
            toogleDtoCreate.State = toggleViewModelCreate.State;
            switch (toggleViewModelCreate.TypeOfActionToogle)
            {
                case TypeToggle.IsButtonBlue:
                    toogleDtoCreate.TypeOfActionToogle = Bussiness.ToggleManager.DTOS.TypeToggleDto.IsButtonBlue;
                    break;
                case TypeToggle.IsButtonGreen:
                    toogleDtoCreate.TypeOfActionToogle = Bussiness.ToggleManager.DTOS.TypeToggleDto.IsButtonGreen; ;
                    break;
                case TypeToggle.IsButtonRed:
                    toogleDtoCreate.TypeOfActionToogle = Bussiness.ToggleManager.DTOS.TypeToggleDto.IsButtonRed; ;
                    break;
                case TypeToggle.None:
                    toogleDtoCreate.TypeOfActionToogle = Bussiness.ToggleManager.DTOS.TypeToggleDto.None; ;
                    break;
                
            }
           

            return toogleDtoCreate;
        }
        public static TypeToggle TypeToggleAction(ToggleDto toggleDto)
        {
           
            switch (toggleDto.TypeOfActionToogle)
            {
                case Bussiness.ToggleManager.DTOS.TypeToggleDto.None:
                    return TypeToggle.None;
                  
                case Bussiness.ToggleManager.DTOS.TypeToggleDto.IsButtonBlue:
                    return TypeToggle.IsButtonBlue;
                    
                case Bussiness.ToggleManager.DTOS.TypeToggleDto.IsButtonRed:
                    return TypeToggle.IsButtonRed;
                    
                case Bussiness.ToggleManager.DTOS.TypeToggleDto.IsButtonGreen:
                    return TypeToggle.IsButtonGreen;
                    

            }
            return TypeToggle.None;
        }
    }
}