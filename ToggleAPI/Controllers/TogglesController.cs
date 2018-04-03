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
     /// <summary>
    /// The Rest Api to manage toogles to Services/Applications by States.
    /// </summary>
    [RoutePrefix("api/toggles")]
    public class TogglesController : ApiController
    {

      

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TogglesController()
        {

        }
       private IClientToggle _clientToggle;
        /// <summary>
        /// ClientToggle Service Api to manage the Toggles
        /// </summary>
        /// <param name="clientToggle"></param>
        public TogglesController(IClientToggle clientToggle)
        {
            _clientToggle =  clientToggle;
        }
        // GET api/toggles
        /// <summary>
        /// List of all toggles from the services/applications and states. 
        /// </summary>
        /// <returns>An list of Toggles.</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ToggleViewModel>))]
        [Route("")]
        public HttpResponseMessage GetToggles()
        {
            HttpResponseMessage response;
            var togglesDtos= _clientToggle.GetAll();
            if (togglesDtos==null)
            {
                  response = Request.CreateResponse(HttpStatusCode.OK, Enumerable.Empty<ToggleViewModel>());
                return response;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, togglesDtos.Select(s => new ToggleViewModel(s)));
            return response;
            

             
        }

        // GET api/toggles/00000000-0000-0000-0000-000000000000/1
        /// <summary>
        /// Obtain the model toggle passing the id and version
        /// of one service/application in specific. 
        /// </summary>
        /// <param name="id">The id of one service/application </param>
        /// <param name="version">The version of one service/application</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(ToggleServiceViewModel))]
        [Route("api/toggles/{id:guid}/{version:int}")]
        public HttpResponseMessage GetToggleByIdAnVersion(Guid id,int version)
        {
            ServiceDto serviceDto = new ServiceDto();
            serviceDto.Id = id;
            serviceDto.Version = version;
            var toggleServiceViewModel = new ToggleServiceViewModel(_clientToggle.GetTogglesServiceByIdAndVersion(serviceDto));
            if (toggleServiceViewModel == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, toggleServiceViewModel);
            return response;
        }

        // POST api/toggles
        /// <summary>
        /// Create one toggle by the model of toogle 
        /// if exists return message in header 'Toggle succsessfuly created' 
        /// if not return not found message.
        /// </summary>
        /// <param name="toggleViewModelCreate">The model toogle to create.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/toggles")]
        [ResponseType(typeof(ToggleViewModelCreate))]
        //[Authorize]
        public HttpResponseMessage Post(ToggleViewModelCreate toggleViewModelCreate)
        {
            var response = new HttpResponseMessage();
            if (ModelState.IsValid)
            {
                ToggleDtoCreate toogleDtoCreate = Helpers.Fillers.FillToggleDtoCreate(toggleViewModelCreate);
                _clientToggle.Add(toogleDtoCreate);

                response = Request.CreateResponse(HttpStatusCode.OK, toggleViewModelCreate);

                response.Headers.Add("CreateMessage", "Toggle succsessfuly created");
                
                return response;
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, toggleViewModelCreate);

                response.Headers.Add("CreateMessageError", "Toggle unsuccsessfuly created");
                return response;
            }





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
       
        public HttpResponseMessage UpdateToggle(ToggleViewModel toggleViewModel)
        {
            var response = new HttpResponseMessage();
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            ToggleDto toggleDtoToUpdate= _clientToggle.GetById(toogleDto);
           
            if (toggleDtoToUpdate==null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, toggleViewModel);
                response.Headers.Add("UpdateMessage", "Toggle succsessfuly updated");
                return response;
               // throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
                _clientToggle.Update(toogleDto);

            response = Request.CreateResponse(HttpStatusCode.OK, toggleViewModel);

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
        [ResponseType(typeof(ToggleViewModel))]

        public HttpResponseMessage Delete(ToggleViewModel toggleViewModel)
        {
            var response = new HttpResponseMessage();
            ToggleDto toogleDto = new ToggleDto();
            toogleDto.Id = toggleViewModel.Id;
            ToggleDto toggleDtoToUpdate = _clientToggle.GetById(toogleDto);

            if (toggleDtoToUpdate == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, toggleViewModel);

                response.Headers.Add("DeleteMessage", "Toggle unsuccsessfuly deleted");
            }
            _clientToggle.Delete(toggleDtoToUpdate);
            response.Headers.Add("DeleteMessage", "Toggle succsessfuly deleted");
            response = Request.CreateResponse(HttpStatusCode.OK, toggleViewModel);

            response.Headers.Add("DeleteMessage", "Toggle succsessfuly deleted");
            return response;
            
        }
    }
}
