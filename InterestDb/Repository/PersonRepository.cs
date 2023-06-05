using InterestDb.Data;
using InterestDb.Models;
using InterestDb.Models.DTO;
using InterestDb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InterestDb.Repository
{
	public class PersonRepository : IPersonRepository
	{
		private readonly ApplicationDbContext _context;

		public PersonRepository(ApplicationDbContext context)
        {
			_context = context;
		}

		public ICollection<Person> GetAllPeople()
		{
			return _context.Persons.ToList();
		}

		public bool PersonExists(int personId)
		{
			return _context.Persons.Any(p => p.PersonId == personId);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}
	}
}
