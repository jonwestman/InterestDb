using AutoMapper;
using InterestDb.Models;
using InterestDb.Models.DTO;
using InterestDb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : Controller
	{
		private readonly IPersonRepository _personRepository;
		private readonly IInterestLinkRepository _interestLinkRepository;
		private readonly IMapper _mapper;

		public PersonController(IPersonRepository personRepository, IInterestLinkRepository interestLinkRepository,IMapper mapper)
        {
			_personRepository = personRepository;
			_interestLinkRepository = interestLinkRepository;
			_mapper = mapper;
		}
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Person>))]
        public IActionResult GetPersons()
		{
			var persons = _mapper.Map<List<PersonDto>>(_personRepository.GetAllPeople());

			if (persons.Count() == 0)
			{
				return NotFound("No people in the database");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(persons);
		}
    }
}
