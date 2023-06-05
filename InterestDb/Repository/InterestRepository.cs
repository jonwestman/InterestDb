using InterestDb.Data;
using InterestDb.Models;
using InterestDb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Repository
{
	public class InterestRepository : IInterestRepository
	{
		private readonly ApplicationDbContext _context;

		public InterestRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool AddInterest([FromBody] Interest interest)
		{
			_context.Add(interest);
			return Save();
		}

		public ICollection<Interest> GetInterest()
		{
			return _context.Interests.ToList();
		}

		public ICollection<Interest> GetInterestByPersonId(int personId)
		{
			var interests = from i in _context.Interests
							join il in _context.InterestLinks on i.InterestId equals il.FK_InterestId
							join p in _context.Persons on il.FK_PersonId equals p.PersonId
							where p.PersonId == personId
							select il.Interest;

			return interests.ToList();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}
	}
}
