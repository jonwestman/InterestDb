using InterestDb.Models;
using InterestDb.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Repository.IRepository
{
	public interface IInterestLinkRepository
	{
		ICollection<InterestLink> GetInterestLink();
		ICollection<InterestLink> GetInterestLinksByPersonId(int personId);
		bool AddInterestLink([FromBody] InterestLink interestLink);
        bool UpdateInterest(InterestLink interestLink);
        bool InterestLinkExists(int interestLinkId);
        bool Save();
	}
}
