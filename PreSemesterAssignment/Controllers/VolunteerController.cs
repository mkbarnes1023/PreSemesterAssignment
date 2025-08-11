using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PreSemesterAssignment.Controllers
{
    public class VolunteerController : Controller
    {
        // Returns the page for viewing the list of volunteers, with the Volunteer Model bound
        public IActionResult VolunteerList()
        {
            return View();
        }

        // Returns the page for adding a volunteer, with the Volunteer Model bound
        public IActionResult VolunteerAdd()
        {
            return View();
        }
    }
}

