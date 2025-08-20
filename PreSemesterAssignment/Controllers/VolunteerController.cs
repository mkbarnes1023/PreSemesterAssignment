using Microsoft.AspNetCore.Mvc;
using PreSemesterAssignment.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PreSemesterAssignment.Models.RepositoryInterfaces;
using PreSemesterAssignment.Models.Repositories;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PreSemesterAssignment.Controllers
{
    public class VolunteerController : Controller
    {
        private IVolunteerRepository VolunteerRepo;

        public VolunteerController(IVolunteerRepository Repository)
        {
            VolunteerRepo = Repository;
        }

        // Returns the page for viewing the list of volunteers
        public IActionResult VolunteerList(string search, int filter)
        {
            // Parses the search query
            var volunteers = VolunteerRepo.Volunteers;
            if (!String.IsNullOrEmpty(search))
            {
                volunteers = volunteers.Where(v => v.FirstName.Contains(search)
                || v.LastName.Contains(search)).ToList();  
            }

            // Parses the chosen filter
            switch (filter)
            {
            // Pending/Approved
            case 1:
                volunteers = volunteers.Where(v => v.ApprovalStatus.Contains("Approved")
                || v.ApprovalStatus.Contains("Pending"));
                break;
            // Approved
            case 2:
                volunteers = volunteers.Where(v => v.ApprovalStatus.Contains("Approved"));
                break;
            // Pending
            case 3:
                volunteers = volunteers.Where(v => v.ApprovalStatus.Contains("Pending"));
                break;

            // Denied
            case 4:
                volunteers = volunteers.Where(v => v.ApprovalStatus.Contains("Rejected"));
                break;

            // All/No filter
            default:
                break;
            }

            return View(volunteers);
        }

        // Returns the page for adding a volunteer
        public IActionResult VolunteerAdd()
        {
            return View();
        }

		public IActionResult DeleteVolunteer(int VolunteerID)
		{
			Console.WriteLine("ID to be removed: " + VolunteerID);
			VolunteerRepo.RemoveVolunteerByID(VolunteerID);
			VolunteerRepo.Save();

			return View("VolunteerList", VolunteerRepo.Volunteers);
		}

		public IActionResult SubmitNewVolunteer(Volunteer newVolunteer)
		{
            // Add the Volunteer to the VolunteerRepo
            Console.WriteLine("Adding a new Volunteer" + newVolunteer);
            VolunteerRepo.AddVolunteer(newVolunteer);
            VolunteerRepo.Save();

			// Redirect to the VolunteerList (With the VolunteerRepo)
			return View("VolunteerList", VolunteerRepo.Volunteers);
		}

        public IActionResult VolunteerEdit(int VolunteerID)
        {
            return View(VolunteerRepo.GetVolunteerByID(VolunteerID));
        }

		public IActionResult SubmitEditedVolunteer(Volunteer UpdatedVolunteer)
		{
            VolunteerRepo.UpdateVolunteer(UpdatedVolunteer);
            VolunteerRepo.Save();

			return View("VolunteerList", VolunteerRepo.Volunteers);
		}
	}
}

