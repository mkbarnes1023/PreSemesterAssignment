using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PreSemesterAssignment.Controllers
{
    public class OpportunityController : Controller
    {
        // Returns the page for viewing the list of opportunities, with the Opportunity Model bound
        public IActionResult OpportunityList()
        {
            return View();
        }

        // Returns the page for adding a opportunity, with the Opportunity Model bound
        public IActionResult OpportunityAdd()
        {
            return View();
        }
    }
}

