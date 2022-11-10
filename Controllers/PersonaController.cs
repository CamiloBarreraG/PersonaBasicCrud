using Microsoft.AspNetCore.Mvc;
using TryPactia.Models;
using TryPactia.Services;



namespace TryPactia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaService _persona;
        public PersonaController(IPersonaService persona)
        {
            _persona=persona;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> Get()
        {
            try
            {
                return Ok(_persona.GetAll());
            }
            catch (Exception ex) 
            { 
            return BadRequest(ex.Message);
            }
        }


        [HttpGet("{cedula}")]
        public ActionResult<Persona> Get(string cedula)
        {
            try { 
            return Ok(_persona.Get(cedula));
            }
            catch(NullReferenceException nEx)
            {
                return BadRequest(nEx.Message);
            }
            catch (Exception ex) 
            { 
            return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Post([FromBody] Persona persona)
        {
            try { 
            _persona.AddPersona(persona);
            return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public ActionResult Put([FromBody] Persona persona)
        {
            try { 
            _persona.Edit(persona);
            return Ok();
            }
            catch(NullReferenceException nEx)
            {
                return BadRequest(nEx.Message);
            }
            catch (Exception ex)
            { 
            return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cedula}")]
        public ActionResult Delete(string cedula)
        {
            try
            {
                _persona.Delete(cedula);
                return Ok();
            }
            
            catch(NullReferenceException nEx)
            {
                return BadRequest(nEx.Message);
            }
            catch (Exception ex) 
            { 
            return BadRequest(ex.Message);
            }
        }
    }
}
