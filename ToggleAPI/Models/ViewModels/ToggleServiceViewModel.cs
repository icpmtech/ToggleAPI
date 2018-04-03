using Bussiness.Dtos.ToggleManager;
using System.Collections.Generic;

namespace ToggleAPI.Models
{
    public class ToggleServiceViewModel
    {
        private TogglesServiceDto togglesServiceDto;
        public List<ToggleViewModel> ToggleViewModels { get; set; }
        public ToggleServiceViewModel(TogglesServiceDto togglesServiceDto)
        {
            ToggleViewModels = new List<ToggleViewModel>();
            foreach (var toggleDto in togglesServiceDto.TogglesDtos)
            {
                ToggleViewModels.Add(new ToggleViewModel(toggleDto));
            }
        }
    }
}