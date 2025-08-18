namespace PreSemesterAssignment.Models.RepositoryInterfaces
{
	public interface IVolunteerRepository
	{
		IEnumerable<Volunteer> Volunteers { get; }
		Volunteer GetVolunteerByID(int VolunteerID);
		void AddVolunteer(Volunteer volunteer);
		void RemoveVolunteerByID(int VolunteerID);
		void UpdateVolunteer(Volunteer volunteer);
		void Save();
	}
}
