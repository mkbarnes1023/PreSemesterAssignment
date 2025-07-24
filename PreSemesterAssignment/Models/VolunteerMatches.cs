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
        public int VolunteerID { get; set; }
        public int OppurtunityID { get; set; }
    }
}