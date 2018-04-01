using Bussiness.Dtos.ToggleManager;
using System;

namespace ToggleAPI.Models
{
    /// <summary>
    /// The type of toggle to activate some logic in the services. 
    /// </summary>
    public enum TypeToggle
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,
        /// <summary>
        /// Toggle Type IsButtonBlue.
        /// </summary>
        IsButtonBlue,
        /// <summary>
        /// Toggle Type IsButtonRed.
        /// </summary>
        IsButtonRed,
        /// <summary>
        /// Toggle Type IsButtonGreen.
        /// </summary>
        IsButtonGreen

    }
    /// <summary>
    /// UI model  toggles  to apply in Services/Applications
    /// </summary>
    public class ToggleViewModel
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public ToggleViewModel()
        {

        }
        /// <summary>
        /// The constructor of the model with the dto to fill the properties.
        /// </summary>
        /// <param name="toggleDto">The ToggleDto to use to manage the logic.</param>
        public ToggleViewModel(ToggleDto toggleDto)
        {
            this.Id = toggleDto.Id;
            
        }
        /// <summary>
        /// The type of toogle to activate service logic
        /// </summary>
        public TypeToggle TypeOfActionToogle { get; set; }
        /// <summary>
        /// Identifier of the toogle model.
        /// </summary>
        public Guid Id { get;  set; }
        
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