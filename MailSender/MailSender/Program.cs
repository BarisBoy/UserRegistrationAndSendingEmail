using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MailSender
{
    class Program    
    { 
        
        static void Main(string[] args)
        {

            while (true)
            {
                Send(); 
            }
        }
        //Checks the unsent emails in 5 seconds.
        private static void Send()
        {
            var timer = new Timer
            {
                Interval = 5000,
                Enabled = true
            };
            timer.Elapsed += new ElapsedEventHandler(TimerElapsedEvent);
        }

        static void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {

            UserRegistiration_DBEntities db = new UserRegistiration_DBEntities();
            
            // The emails are sent in order by id.
            var toBeSendMails = db.Mail
                .Where(x=>x.IsSend==false)
                .OrderBy(x=>x.AutoID)
                .ToList();

                            foreach (var mail in toBeSendMails)
                	{
                		 SendMailMethods(mail);
                	}
	
        }
         static void SendMailMethods(Mail mail)
        {
            //Field for operations of sending email
            UserRegistiration_DBEntities db = new UserRegistiration_DBEntities();
            
            mail.IsSend = true;
            mail.SendToDate = DateTime.Now;

            db.SaveChanges();
        }
 
    }

}
