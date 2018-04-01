using Bussiness.Dtos.ToggleManager;
using System;

namespace ToggleAPI.Models
{
   /// <summary>
   /// UI model create toggles  to apply in Services/Applications
   /// </summary>
    public class ToggleViewModelCreate
    {
       
        /// <summary>
        /// Default constructor
        /// </summary>
        public ToggleViewModelCreate()
        {

        }
       
        /// <summary>
        /// The type of toogle to activate service logic
        /// </summary>
        public TypeToggle TypeOfActionToogle { get; set; }
        
        
        /// <summary>
        /// The service identifier to assign to toogle.
        /// </summary>
        public Guid ServiceId { get; set; }
        /// <summary>
        /// The version of service.
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// The state of the service by version, id and toogle.
        /// </summary>
        public bool State { get; set; }
    }
}