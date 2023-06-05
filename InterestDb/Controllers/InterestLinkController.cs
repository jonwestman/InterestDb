using AutoMapper;
using InterestDb.Models;
using InterestDb.Models.DTO;
using InterestDb.Repository;
using InterestDb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InterestDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InterestLinkController : Controller
	{
		private readonly IInterestLinkRepository _interestLinkRepository;
		private readonly IMapper _mapper;

		public InterestLinkController(IInterestLinkRepository interestLinkRepository, IMapper mapper)
		{
			_interestLinkRepository = interestLinkRepository;
			_mapper = mapper;
		}
		[HttpGet("personId")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<InterestLink>))]
		public IActionResult GetInterestLinkById(int personId)
		{
			var interestLink = _mapper.Map<List<InterestLinkDto>>(_interestLinkRepository.GetInterestLinksByPersonId(personId));

			if (interestLink.Count() == 0)
			{
				return NotFound("No links in the database");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(interestLink);
		}

		[HttpPost]
		[ProducesResponseType(200)]
		public IActionResult AddInterestLink([FromBody] InterestLinkAddDto interestLinkCreate)
		{
			if (interestLinkCreate == null)
			{
				return BadRequest(ModelState);
			}

			var interestLink = _interestLinkRepository.GetInterestLink()
				.Where(c => c.URL.Trim().ToUpper() == interestLinkCreate.URL.TrimEnd().ToUpper())
				.FirstOrDefault();

			if (interestLink != null)
			{
				ModelState.AddModelError("", "InterestLink already exists");
				return StatusCode(422, ModelState);
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var interestLinkMap = _mapper.Map<InterestLink>(interestLinkCreate);

			if (!_interestLinkRepository.AddInterestLink(interestLinkMap))
			{
				ModelState.AddModelError("", "Something went wrong while saving");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully Created");
		}
        [HttpPut("{interestLinkId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateInterest(int interestLinkId, [FromBody] InterestLinkDto updatedInterest)
        {
            if (updatedInterest == null)
            {
                return BadRequest(ModelState);
            }

            if (interestLinkId != updatedInterest.InterestLinkId)
            {
                return BadRequest(ModelState);
            }

            if (!_interestLinkRepository.InterestLinkExists(interestLinkId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var interestLinkMap = _mapper.Map<InterestLink>(updatedInterest);

            if (!_interestLinkRepository.UpdateInterest(interestLinkMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Interestlink");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated successfully");
        }
    }
}
