using InterestDb.Data;
using InterestDb.Models;
using InterestDb.Models.DTO;
using InterestDb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Repository
{
	public class InterestLinkRepository : IInterestLinkRepository
	{
		private readonly ApplicationDbContext _context;

		public InterestLinkRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public bool AddInterestLink([FromBody] InterestLink interestLink)
		{
			_context.Add(interestLink);
			return Save();
		}

		public ICollection<InterestLink> GetInterestLink()
		{
			return _context.InterestLinks.ToList();
		}

		public ICollection<InterestLink> GetInterestLinksByPersonId(int personId)
		{
			return _context.InterestLinks.Where(i => i.FK_PersonId == personId).ToList();
		}

        public bool InterestLinkExists(int interestLinkId)
        {
            return _context.InterestLinks.Any(p => p.InterestLinkId == interestLinkId);
        }

        public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}

        public bool UpdateInterest(InterestLink interestLink)
        {
			_context.Update(interestLink);
			return Save();
        }
    }
}
