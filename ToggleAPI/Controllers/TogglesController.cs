using Bussiness.Dtos.ToggleManager;
using Service.ClientToggle;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToggleAPI.Models;

namespace ToggleAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/toggles")]
    public class TogglesController : ApiController
    {
        public TogglesController()
        {

        }
       private IClientToggle _clientToggle;
        public TogglesController(IClientToggle clientToggle)
        {
            _clientToggle =  clientToggle;
        }
        // GET api/toggles
        /// <summary>
        /// This 
        /// </summary>
        /// <returns>An list of Toggles</returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<ToggleViewModel> GetToggles()
        {
            var togglesDtos= _clientToggle.GetAll();
            if (togglesDtos==null)
            {
                return Enumerable.Empty<ToggleViewModel>();
            }
            return togglesDtos.Select(s => new ToggleViewModel(s));
             
        }

        // GET api/toggles/5
        [HttpGet]
        public ToggleViewModel Details(ToggleViewModel toggleViewModel)
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            return new ToggleViewModel(_clientToggle.GetById(toogleDto));
        }

        // POST api/toggles
        [HttpPost]
        public ToggleViewModel Post(ToggleViewModel toggleViewModel )
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            _clientToggle.Add(toogleDto);
            return toggleViewModel;

        }

        // PUT api/toggles/toggleViewModel
        [HttpPut]
        public HttpResponseMessage Put(ToggleViewModel toggleViewModel)
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            ToggleDto toggleDtoToUpdate= _clientToggle.GetById(toogleDto);
           
            if (toggleDtoToUpdate==null)
            {

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
                _clientToggle.Update(toogleDto);
                var response = new HttpResponseMessage();
                response.Headers.Add("Message", "Toggle succsessfuly updated");
                return response;
            
            
        }

        // DELETE api/toggles/toggleViewModel
        [HttpDelete]
        public HttpResponseMessage Delete(ToggleViewModel toggleViewModel)
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            ToggleDto toggleDtoToUpdate = _clientToggle.GetById(toogleDto);

            if (toggleDtoToUpdate == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _clientToggle.Delete(toggleDtoToUpdate);
            var response = new HttpResponseMessage();
            response.Headers.Add("DeleteMessage", "Toggle succsessfuly deleted");
            return response;
            
        }
    }
}
