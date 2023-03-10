using NumerologiaCabalistica.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace NumerologiaCabalistica.Service
{
    public static class ServiceMessenger
    {

        public static void SendMail(Customer customer)
        {
                string firstName = customer.NomeCompleto.Split(' ')[0];
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "smtp.hostinger.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("contato@talesyossef.com.br", "Aac#j100174");

                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("contato@talesyossef.com.br", "Tales Yossef");
                message.Body = $"<strong>{firstName}</strong>, tenho novidades. Seu mapa está finalizado e está anexado neste e-mail.\r\n\r\n\r\n\r\n" +
                    $"Leia e releia quantas vezes quiser. Quanto mais você ler, maior será o seu entendimento.\r\n\r\n\r\n\r\n" +
                    $"<br/><br/>" +
                    $"Lembre-se: uma leitura nunca será igual a outra. Um livro lido pela segunda, terceira, quarta vez, e assim por diante, sempre será diferente pois seu nível de percepção aumentará.\r\n\r\n \r\n\r\n" +
                    $"<br/><br/>" +
                    $"<strong>Dica de Leitura </strong>" +
                    $"<br/><br/>" +
                    $"Este será seu livro principal pois é o livro da sua vida. Portanto, antes de ler, procure um local silencioso sem movimentações e confortável…\r\n\r\n\r\n\r\n" +
                    $"<br/><br/>" +
                    $"Sente, relaxe…Indico você colocar um som que eleve a sua vibração. Vou deixar abaixo uma sugestão de som para ouvir durante a leitura.\r\n\r\n \r\n\r\n" +
                    $"<br/><br/>" +
                    $"https://www.youtube.com/watch?v=sOqJHFwPMz4" +
                    $"<br/><br/>" +
                    $"Coloque bem baixinho, se tiver fone de ouvido, coloque-o em um volume que não te incomode.\r\n\r\n\r\n\r\n" +
                    $"<br/><br/>" +
                    $"Respire fundo 5x, se conecte com sua respiração e jogue uma intenção para o universo para que esta leitura lhe traga clareza que você precisa no momento.\r\n\r\n\r\n\r\n" +
                    $"<br/><br/>" +
                    $"<br>" +
                    $"A cada leitura, você terá uma nova percepção e algum novo insight que vai te levar para o próximo nível.\r\n\r\n\r\n\r\n" +
                    $"<br/><br/>" +
                    $"Tenha uma ótima leitura e conte comigo.\r\n\r\n \r\n\r\n" +
                    $"<br/><br/>" +
                    $"Com Amor,\r\n\r\n" +
                    $"<br/><br/>" +
                    $"Talles Yossef";

                message.Subject = $"{firstName}, seu Mapa Cabalístico chegou";

                string currentDirectory = Directory.GetCurrentDirectory();
                string file = Path.Combine(currentDirectory, customer.MapFile);
                message.Attachments.Add(new Attachment(file));
                message.Bcc.Add(new MailAddress("contato@talesyossef.com.br"));

                message.Priority = MailPriority.Normal;
                message.To.Add(customer.Email);

                try
                {
                    smtpClient.Send(message);
                }
                catch (SmtpException ex)
                {
                    throw new SmtpException(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
