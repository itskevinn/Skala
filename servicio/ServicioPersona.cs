using System;
using datos;
using entity;
using System.Collections.Generic;
using System.Linq;
namespace servicio
{
  public class ServicioPersona
  {
    private readonly SkalaContext _context;
    public ServicioPersona(SkalaContext context)
    {
      _context = context;
    }
    public GuardarPersonaResponse Guardar(Persona persona)
    {
      try
      {
        var ajusteInventarioBuscado = _context.Personas.Find(persona.Email);
        if (ajusteInventarioBuscado != null)
        {
          return new GuardarPersonaResponse("¡Ajuste de inventario ya registrado!");
        }
        _context.Personas.Add(persona);
        _context.SaveChanges();
        return new GuardarPersonaResponse(persona);
      }
      catch (Exception e)
      {
        return new GuardarPersonaResponse(e.Message);
      }
    }

    public List<Persona> Consultar()
    {
      List<Persona> personas = _context.Personas.ToList();
      return personas;
    }
    public class GuardarPersonaResponse
    {
      public bool Error { get; set; }
      public string Mensaje { get; set; }
      public Persona Persona { get; set; }
      public GuardarPersonaResponse(Persona persona)
      {
        Error = false;
        Persona = persona;
      }
      public GuardarPersonaResponse(string mensaje)
      {
        Mensaje = mensaje;
        Error = true;
      }
    }
  }
}
