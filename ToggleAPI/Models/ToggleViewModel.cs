using Bussiness.Dtos.ToggleManager;

namespace ToggleAPI.Models
{
    public class ToggleViewModel
    {
        private ToggleDto s;

        public ToggleViewModel(ToggleDto s)
        {
            this.s = s;
            ToggleAPI.Helpers.Utils.CreateLinks(this);
        }

        public int Id { get; internal set; }
    }
}