using System;
using System.ComponentModel.DataAnnotations;
namespace entity
{
  public class Persona
  {
    [Key]
    [Required(ErrorMessage = "Ingrese un correo")]
    [StringLength(50, ErrorMessage = "Ingrese un correo válido")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo válido")]
    public string Email { get; set; }
    [StringLength(40, ErrorMessage = "Ingrese un nombre válido")]
    [Required(ErrorMessage = "Ingrese su nombre")]
    public string Nombre { get; set; }
  }
}
