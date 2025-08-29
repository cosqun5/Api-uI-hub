using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.FeatureDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public FeaturesController(IMapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		[HttpGet]
		public IActionResult FeatureList()
		{
			var value = _context.Features.ToList();
			return Ok(_mapper.Map<List<ResultFeatureDto>>(value));
		}
		[HttpPost]
		public IActionResult CreateFeature(CreatFeatureDto creatFeatureDto)
		{
			var value = _mapper.Map<Feature>(creatFeatureDto);
			_context.Features.Add(value);
			//_context.SaveChanges();
			return Ok("Feature created");
		}
		[HttpDelete]
		public IActionResult DeleteFeature(int id)
		{
			var value = _context.Features.Find(id);
			_context.Features.Remove(value);
			_context.SaveChanges();
			return Ok("Feature deleted");
		}
		[HttpGet("GetFeature")]
		public IActionResult GetFeature(int id)
		{
			var value = _context.Features.Find(id);
			return Ok(_mapper.Map<GetByIdFeatureDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			var value = _mapper.Map<Feature>(updateFeatureDto);
			_context.Features.Update(value);
			_context.SaveChanges();
			return Ok("Feature Updated");
		}
	}
}
