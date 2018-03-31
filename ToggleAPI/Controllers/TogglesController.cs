using Bussiness.Dtos.ToggleManager;
using Presentation.ClientToggle;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToggleAPI.Models;

namespace ToggleAPI.Controllers
{
    [Authorize]
    public class TogglesController : ApiController
    {
       private IClientToggle _clientToggle;
        public TogglesController(ClientToggle clientToggle)
        {
            _clientToggle = clientToggle;
        }
        // GET api/toggles
        /// <summary>
        /// This 
        /// </summary>
        /// <returns>An list of Toggles</returns>
        public IEnumerable<ToggleViewModel> Get()
        {
            var togglesDtos= _clientToggle.GetAll();
            return togglesDtos.Select(s => new ToggleViewModel(s));
             
        }

        // GET api/toggles/5
        public ToggleViewModel Get(ToggleViewModel toggleViewModel)
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            return new ToggleViewModel(_clientToggle.GetById(toogleDto));
        }

        // POST api/toggles
        public ToggleViewModel Post(ToggleViewModel toggleViewModel )
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            _clientToggle.Add(toogleDto);
            return toggleViewModel;

        }

        // PUT api/toggles/5
        public ToggleViewModel Put(ToggleViewModel toggleViewModel)
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            _clientToggle.Update(toogleDto);
            return toggleViewModel;
        }

        // DELETE api/toggles/5
        public void Delete(ToggleViewModel toggleViewModel)
        {
           
        }
    }
}
