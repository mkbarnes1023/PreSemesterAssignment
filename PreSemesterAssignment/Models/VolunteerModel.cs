using System.ComponentModel.DataAnnotations;

namespace PreSemesterAssignment.Models
{
    // This Model holds information about the volunteers registered to the volunteer system
    public class VolunteerModel
    {
        // Datatypes with a question mark are nullable fields
        public int VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[]? PreferedCenters { get; set; }
        public string[]? SkillsAndInterests { get; set; }
        public TimeOnly[]? AvailableTimes { get; set; }
        public string HomeAddress { get; set; }
        public string ContactNumbers { get; set; }
        public string EmailAddress { get; set; }
        public string? EducationLevel { get; set; }
        public string[]? CurrentLicenses { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactContactNumber { get; set; }
        public string? EmergencyContactEmailAddress { get; set; }
        public string? EmergencyContactHomeAddress { get; set; }
        public bool DriversLicenseOnFile { get; set; }
        public bool SSNCardOnFile { get; set; }
        // Perhaps ApprovalStatus could be changed to an Enumerated value, 
        // with numbers representing states like "Pending", "Approved", and "Rejected"?
        // See commented code:
        /*
        public enum ApprovalState 
        {
            Pending,
            Approved,
            Rejected
        }
        public ApprovalState ApprovalStatus { get; set; }
        */
        public string ApprovalStatus { get; set; }
        
    }
    
}