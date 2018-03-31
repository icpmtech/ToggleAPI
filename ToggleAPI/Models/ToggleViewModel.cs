using Bussiness.Dtos.ToggleManager;
using System;

namespace ToggleAPI.Models
{
    public class ToggleViewModel
    {
        private ToggleDto s;

        public ToggleViewModel(ToggleDto s)
        {
            this.s = s;
           
        }

        public Guid Id { get; internal set; }
       public  enum Type
        {
            IsButtonBlue, IsButtonRed, IsButtonGreen

        }
        public Guid ServiceId { get; set; }
        public int Version { get; set; }
        public bool State { get; set; }
    }
}