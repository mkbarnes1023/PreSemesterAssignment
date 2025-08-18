using Microsoft.EntityFrameworkCore;
using PreSemesterAssignment.Data;
using PreSemesterAssignment.Models.RepositoryInterfaces;

namespace PreSemesterAssignment.Models.Repositories
{
	public class VolunteerRepository : IVolunteerRepository
	{

		private ApplicationDbContext context;
		public IEnumerable<Volunteer> Volunteers => context.Volunteers;

		public VolunteerRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IEnumerable<Volunteer> GetVolunteers()
		{
			return context.Volunteers.ToList();
		}

		public Volunteer GetVolunteerByID(int VolunteerID)
		{
			return context.Volunteers.Find(VolunteerID);
		}

		public void AddVolunteer(Volunteer volunteer)
		{
			context.Volunteers.Add(volunteer);
		}

		public void RemoveVolunteerByID(int VolunteerID)
		{
			context.Volunteers.Remove(context.Volunteers.Find(VolunteerID));
		}

		public void UpdateVolunteer(Volunteer volunteer)
		{
			context.Volunteers.Update(volunteer);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
