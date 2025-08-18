using Microsoft.AspNetCore.Mvc;
using PreSemesterAssignment.Models;
using PreSemesterAssignment.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PreSemesterAssignment.Controllers
{
    public class OpportunityController : Controller
    {
        // Add a Repository to store and interact with the Opportunity data
        private IOpportunityRepository OpportunityRepo;

		public OpportunityController(IOpportunityRepository Repository)
        {
			OpportunityRepo = Repository;
		}

		// Returns the page for viewing the list of opportunities
		public IActionResult OpportunityList()
        {
            Console.WriteLine("Controller for OpportunityList: " + OpportunityRepo);
            foreach(Opportunity o in OpportunityRepo.Opportunities)
            {
                Console.WriteLine("Opportunity: " + o.Center);
			}
			return View("OpportunityList", OpportunityRepo.Opportunities);
        }

        // Returns the page for adding a opportunity
        public IActionResult OpportunityAdd()
        {
            return View();
        }

        // Handler for the submit button 
        public IActionResult SubmitNewOpportunity(Opportunity newOpportunity)
        {
            // Fill DateAdded field with the current date
            newOpportunity.DateAdded = DateOnly.FromDateTime(DateTime.Now);
            OpportunityRepo.AddOpportunity(newOpportunity);

            OpportunityRepo.Save();

            // Redirect to the OpportunityList (With the OpportunityRepo)
            return View("OpportunityList", OpportunityRepo.Opportunities);
        }

        public IActionResult DeleteOpportunity(int OpportunityID)
        {
            Console.WriteLine("ID to be removed: " + OpportunityID);
            OpportunityRepo.RemoveOpportunityByID(OpportunityID);
            OpportunityRepo.Save();

            return View("OpportunityList", OpportunityRepo.Opportunities);
        }
    }
}

