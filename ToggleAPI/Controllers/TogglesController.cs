using Bussiness.Dtos.ToggleManager;
using Service.ClientToggle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToggleAPI.Models;

namespace ToggleAPI.Controllers
{
    //[Authorize]
    /// <summary>
    /// The Rest Api to manage toogles.
    /// </summary>
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
        /// List of all toggles. 
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

        // GET api/toggles/00000000-0000-0000-0000-000000000000/1
        /// <summary>
        /// Obtain the model toggle passing the id and version of one toggle in specific. 
        /// </summary>
        /// <param name="id">The id of one toogle</param>
        /// <param name="version">The version of one toogle</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/toggles/{id:guid}/{version:int}")]
        public ToggleViewModel Details(Guid id,int version)
        {
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = id;
            toogleDto.Version = version;
            return new ToggleViewModel(_clientToggle.GetById(toogleDto));
        }

        // POST api/toggles
        /// <summary>
        /// Create one toggle by the model of toogle 
        /// if exists return message in header 'Toggle succsessfuly created' 
        /// if not return not found message.
        /// </summary>
        /// <param name="toggleViewModel">The model toogle to create.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/toggles")]
        [ResponseType(typeof(ToggleViewModel))]
        public HttpResponseMessage Post(ToggleViewModel toggleViewModel )
        {
            var response = new HttpResponseMessage();
            if (ModelState.IsValid)
            {
                ToggleDto toogleDto = new ToggleDto();
                toogleDto.Id = toggleViewModel.Id;
                _clientToggle.Add(toogleDto);
              
                response.Headers.Add("CreateMessage", "Toggle succsessfuly created");
                return response;
            }
            
            response.Headers.Add("CreateMessageError", "Toggle unsuccsessfuly created");
            return response;


        }

        // PUT api/toggles/toggleViewModel
        /// <summary>
        /// Update one toggle by the model of toogle 
        /// if exists return message in header 'Toggle succsessfuly updated' 
        /// if not return not found message.
        /// </summary>
        /// <param name="toggleViewModel">The model toogle to update.</param>
        /// <returns>An http response message with the model toggle update.</returns>
        [HttpPut]
        [Route("api/toggles")]
        [ResponseType(typeof(ToggleViewModel))]
       
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
                response.Headers.Add("UpdateMessage", "Toggle succsessfuly updated");
                return response;
            
            
        }

        // DELETE api/toggles/toggleViewModel
        /// <summary>
        /// Delete one toggle by the model of toogle 
        /// if exists return message in header 'Toggle succsessfuly deleted' 
        /// if not return not found message.
        /// </summary>
        /// <param name="toggleViewModel">The model toogle to delete.</param>
        /// <returns>An http response message with the model toggle delete.</returns>
        [HttpDelete]
        [Route("api/toggles")]
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
