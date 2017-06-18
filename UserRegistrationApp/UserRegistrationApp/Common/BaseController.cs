using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Common
{
    public class BaseController:Controller
    {

        public bool SendMail(string to,string from,string mailTemplateCode,string cc=null)
        {
            UserRegistiration_DBEntities db = new UserRegistiration_DBEntities();

            if ( String.IsNullOrEmpty(to) || String.IsNullOrEmpty(from) || String.IsNullOrEmpty(mailTemplateCode))
            {
                return false;
            }

            var mailTemplate= db.MailTemplate
                .Where(x => x.Code == mailTemplateCode)
                .FirstOrDefault();

            if (mailTemplate==null)
            {
                return false;
            }

            // That structure provides us to assign initial values.


            Mail sendMail = new Mail 
            {
                ID=Guid.NewGuid(),
                To=to,
                Cc=cc,
                From=from,
                Subject=mailTemplate.Subject,
                Body=mailTemplate.Body,
                IsSend=false,             
                CreatedDate=DateTime.Now            
            };

            db.Mail.Add(sendMail);
            db.SaveChanges();

            return true;
        }
    }
}