using ApiProject.WepApi.Context;
using ApiProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChefController : ControllerBase
	{
		private readonly ApiContext _context;

		public ChefController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Chef()
		{
			var value = _context.Chefs.ToList();
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateChef(Chef chef) 
		{
			_context.Chefs.Add(chef);
			_context.SaveChanges();
			return Ok("Chef created");
		}
		[HttpDelete]
		public IActionResult DeleteChef(int id)
		{
			var value = _context.Chefs.Find(id);
			_context.Chefs.Remove(value);
			_context.SaveChanges();
			return Ok("Chef deleted");
		}
		[HttpGet("GetChef")]
		public IActionResult GetChef(int id)
		{
			return Ok(_context.Chefs.Find(id));
		}

		[HttpPut]
		public IActionResult UpdateChef(Chef chef)
		{
		    _context.Chefs.Update(chef);
			_context.SaveChanges();
			return Ok("chef updated");
		}
	}
}
