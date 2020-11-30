using System;
using System.Net.Mail;
using entity;

namespace infraestructura
{
  public class Email
  {
    private MailMessage email;
    private SmtpClient smtp;
    public Email()
    {
      smtp = new SmtpClient();
    }
    private void ConfigurarSmt()
    {
      smtp.Host = "smtp.gmail.com";
      smtp.Port = 587;
      smtp.EnableSsl = true;
      smtp.UseDefaultCredentials = false;
      smtp.Credentials = new System.Net.NetworkCredential("keviinpn4@gmail.com",
      "Kevin.2!");
    }
    private void ConfigurarEmail(Persona persona)
    {
      email = new MailMessage();
      email.To.Add(persona.Email);
      email.From = new MailAddress("bycbas@gmail,com");
      email.Subject = "Prueba página "
      + DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss");
      email.Body = $"<b>Sr {persona.Nombre }</b> <br " +
      $" > se ha realizado su registro satisfactoriamente y ahora te va a llegar spam jaja salu2";
      email.IsBodyHtml = true;
      email.Priority = MailPriority.High;
    }
    public string EnviarEmail(Persona persona)
    {

      try
      {
        ConfigurarSmt();
        ConfigurarEmail(persona);
        smtp.Send(email);
        return ("Correo enviado Satifactoriamente");
      }
      catch (Exception e)
      {
        return ("error al enviar correo" + e.Message);
      }
      finally
      {
        email.Dispose();
      }
    }
  }
}
