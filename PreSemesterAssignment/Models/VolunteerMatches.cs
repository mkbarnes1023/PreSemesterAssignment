using System.ComponentModel.DataAnnotations;

namespace PreSemesterAssignment.Models
{
    /**
    * This Model stores matches between Volunteers and Opportunities.
    * I'm not certain whether Volunteers matched to an Opportunity are 
    * registered to that Opportunity, or merely reccomended for it
    */
    public class VolunteerMatchesModel
    {
        // Both are Foreign Keys
        public int VolunteerID { get; set; }
        public int OppurtunityID { get; set; }
    }
}