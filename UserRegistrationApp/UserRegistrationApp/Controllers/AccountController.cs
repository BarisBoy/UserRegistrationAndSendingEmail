using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationApp.Common;
using UserRegistrationApp.Models;
using UserRegistrationApp.VM;

namespace UserRegistrationApp.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            UserRegistiration_DBEntities db = new UserRegistiration_DBEntities();

            // To list members registered.
            var data = db.User.ToList();
            return View(data);
        }
        public ActionResult Register()
        {
            RegisterVM vm = new RegisterVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // For secure post method
        public ActionResult Register(RegisterVM vm)
        {
            UserRegistiration_DBEntities db = new UserRegistiration_DBEntities();

            //Creating the Globally Unique IDentifier
            vm.User.ID = Guid.NewGuid();
            var user= db.User.Add(vm.User);
           
            vm.Person.UserID=user.ID;
            vm.Person.ID = Guid.NewGuid();
            db.InvitedPerson.Add(vm.Person);
           
            db.SaveChanges();

           var mailSuccess= SendMail(to: vm.Person.Email, from: vm.User.UserName, mailTemplateCode: MailTemplates.InvitedPersonMailCode);

           if (mailSuccess)
           {
              //A message can be prepared for successfull mail.
           }
          
            return RedirectToAction("Index");
        }

        //Login 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (UserRegistiration_DBEntities db= new UserRegistiration_DBEntities())
            {
                var usr = db.User.Single(u => u.UserName == user.UserName /*&& u.Password == user.Password*/);

                if(usr != null)
                {
                    Session["UserId"] =usr.ID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ya da şifre hatalı.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}