using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesPolymor
{
    public interface INotificationChannel
    {
        void Send(Message message);
    }

    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
    }

    public class MailNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending mail...");
        }
    }

    public class SmsNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending SMS...");
        }
    }

    public class VideoEncoder
    {
        // private readonly MailService _mailService;

        private readonly IList<INotificationChannel> _notificationChannels;

        public VideoEncoder()
        {
            // _mailService = new MailService();

            _notificationChannels = new List<INotificationChannel>();
        }

        public void Encode(Video video)
        {
            // Video encoding logic
            // ...

            // _mailService.Send(new Mail());

            foreach (var channel in _notificationChannels)
            {
                channel.Send(new Message());
            }
        }

        public void RegisterNotificationChannel(INotificationChannel channel)
        {
            _notificationChannels.Add(channel);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MailService
    {
        public void Send(Mail mail)
        {
            Console.WriteLine("Sending mail...");
        }
    }

    public class Mail
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var encoder = new VideoEncoder();
            encoder.RegisterNotificationChannel(new MailNotificationChannel());
            encoder.RegisterNotificationChannel(new SmsNotificationChannel());
            encoder.Encode(new Video());
        }
    }
}
