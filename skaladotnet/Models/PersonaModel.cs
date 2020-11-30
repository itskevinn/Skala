using System;
using entity;
namespace Models
{
  public class PersonaModel
  {
    public class PersonaInputModel : Persona
    {
    }

    public class PersonaViewModel : PersonaInputModel
    {
      public PersonaViewModel(Persona persona)
      {
        Nombre = persona.Nombre;
        Email = persona.Email;
      }
    }
  }
}
