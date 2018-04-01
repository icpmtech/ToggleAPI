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
            toogleDtoCreate.TypeOfActionToogle = (int) toggleViewModelCreate.TypeOfActionToogle;
            return toogleDtoCreate;
        }
    }
}