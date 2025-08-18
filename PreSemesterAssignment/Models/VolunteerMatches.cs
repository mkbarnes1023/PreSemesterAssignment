using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreSemesterAssignment.Models
{
    /**
    * This Model stores matches between Volunteers and Opportunities.
    * Volunteers matched to an Opportunity are either registered or recommended for it.
    */
    public class VolunteerMatchesModel
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key to VolunteerModel
        [ForeignKey(nameof(Volunteer))]
        public int VolunteerID { get; set; }
        public Volunteer Volunteer { get; set; }

        // Foreign Key to OpportunityModel
        [ForeignKey(nameof(Opportunity))]
        public int OppurtunityID { get; set; }
        public Opportunity Opportunity { get; set; }
    }
}