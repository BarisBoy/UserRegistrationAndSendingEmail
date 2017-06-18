using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.VM
{
    // This ViewModel is used to avoid errors that can occur using ViewBag in the User and InvitedPerson classes

    public class RegisterVM
    {
        public User User { get; set; }
        public InvitedPerson Person { get; set; }
    }
}