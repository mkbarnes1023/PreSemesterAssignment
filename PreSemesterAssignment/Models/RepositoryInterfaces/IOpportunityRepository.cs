namespace PreSemesterAssignment.Models.RepositoryInterfaces
{
	public interface IOpportunityRepository
	{
		IEnumerable<Opportunity> Opportunities { get; }
		Opportunity GetOpportunityByID(int OpportunityID);
		void AddOpportunity(Opportunity opportunity);
		void RemoveOpportunityByID(int OpportunityID);
		void UpdateOpportunity(Opportunity opportunity);
		void Save();
	}
}
