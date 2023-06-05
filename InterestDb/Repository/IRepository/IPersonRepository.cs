using InterestDb.Models;
using InterestDb.Models.DTO;

namespace InterestDb.Repository.IRepository
{
	public interface IPersonRepository
	{
		ICollection<Person> GetAllPeople();
		bool PersonExists(int personId);
		bool Save();
	}
}
