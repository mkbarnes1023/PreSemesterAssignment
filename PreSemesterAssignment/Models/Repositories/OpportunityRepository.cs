using Microsoft.EntityFrameworkCore;
using PreSemesterAssignment.Data;
using PreSemesterAssignment.Models.RepositoryInterfaces;

namespace PreSemesterAssignment.Models.Repositories
{
	public class OpportunityRepository : IOpportunityRepository
	{

		private ApplicationDbContext context;
		public IEnumerable<Opportunity> Opportunities => context.Opportunities;

		public OpportunityRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IEnumerable<Opportunity> GetOpportunities()
		{
			return context.Opportunities.ToList();
		}

		public Opportunity GetOpportunityByID(int OpportunityID)
		{
			return context.Opportunities.Find(OpportunityID);
		}

		public void AddOpportunity(Opportunity opportunity)
		{
			context.Opportunities.Add(opportunity);
		}

		public void RemoveOpportunityByID(int OpportunityID)
		{
			context.Opportunities.Remove(context.Opportunities.Find(OpportunityID));
		}

		public void UpdateOpportunity(Opportunity opportunity)
		{
			context.Opportunities.Update(opportunity);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
