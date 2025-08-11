using System.ComponentModel.DataAnnotations;

namespace PreSemesterAssignment.Models
{
    /**
    * This Model holds information about the volunteer oppurtunities available
    */
    public class OppurtunityModel
    {
        // Primary Key
        public int OppurtunityID { get; set; }
        public string Description { get; set; }
        public string Center { get; set; }
        public DateOnly DateAdded { get; set; }
    }
}