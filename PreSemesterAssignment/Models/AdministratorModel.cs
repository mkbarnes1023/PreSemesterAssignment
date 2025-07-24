using System.ComponentModel.DataAnnotations;

namespace PreSemesterAssignment.Models
{
    /**
    * This model holds information about the administrators that log into the web portal
    * Currently only holds login credentials, but can be used for more if needed
    */
    public class AdministratorModel
    {
        // Storage of Username/Password is a temporary solution, Identity framework should be used
        public string Username { get; set; }
        public string Password { get; set; }
    }
}