using entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servicio;
using datos;
using static Models.PersonaModel;

namespace skaladotnet.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonaController : ControllerBase
  {
    private readonly ServicioPersona servicioPersona;
    public PersonaController(SkalaContext context)
    {
      servicioPersona = new ServicioPersona(context);
    }

    // POST: api/Persona
    [HttpPost]
    public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
    {
      Persona persona = MapToPersona(personaInput);
      var response = servicioPersona.Guardar(persona);
      if (response.Error)
      {
        ModelState.AddModelError("Error al registrar bodega", response.Mensaje);
        var detallesProblema = new ValidationProblemDetails(ModelState)
        {
          Status = StatusCodes.Status400BadRequest
        };
        return BadRequest(detallesProblema);
      }
      return Ok(response.Persona);
    }
    private Persona MapToPersona(PersonaInputModel personaInput)
    {
      var persona = new Persona
      {
        Email = personaInput.Email,
        Nombre = personaInput.Nombre
      };
      return persona;
    }
  }
}
