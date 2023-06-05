using AutoMapper;
using InterestDb.Models;
using InterestDb.Models.DTO;
using InterestDb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InterestController : Controller
	{
		private readonly IInterestRepository _interestRepository;
		private readonly IMapper _mapper;

		public InterestController(IInterestRepository interestRepository, IMapper mapper)
        {
			_interestRepository = interestRepository;
			_mapper = mapper;
		}
        [HttpGet("personId")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Interest>))]
		public IActionResult GetInterestByPersonId(int personId)
		{
			var interests = _mapper.Map<List<InterestDto>>(_interestRepository.GetInterestByPersonId(personId));

			if (interests.Count == 0)
			{
				return NotFound("No interests in database");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(interests);
		}
	}
}
