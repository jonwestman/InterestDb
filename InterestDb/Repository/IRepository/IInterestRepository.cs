using InterestDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Repository.IRepository
{
	public interface IInterestRepository
	{
		ICollection<Interest> GetInterest();
		ICollection<Interest> GetInterestByPersonId(int personId);
		bool AddInterest([FromBody] Interest interest);
		bool Save();
	}
}
