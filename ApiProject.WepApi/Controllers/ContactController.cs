using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.ContactDtos;
using ApiProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly ApiContext _context;

		public ContactController(ApiContext context)
		{
			_context = context;
		}
		[HttpGet]

		public IActionResult ContactList()
		{
			var values = _context.Contacts.ToList();
			return Ok(values);

		}
		[HttpPost]
		public IActionResult CreateContact(CreatContactDto createContactDto)
		{
			Contact contact = new Contact();
			contact.Email = createContactDto.Email;
			contact.Address = createContactDto.Address;
			contact.Phone = createContactDto.Phone;
			contact.Maploctaion = createContactDto.Maploctaion;
			contact.OpenHours = createContactDto.OpenHours;
			_context.Contacts.Add(contact);
			_context.SaveChanges();
			return Ok("contact created");
		}
		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return Ok("contact deleted");
		}
		[HttpGet("GetContact")]
		public IActionResult GetConatc(int id)
		{
			var value = _context.Contacts.Find(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			Contact contact = new Contact();
			contact.Email = updateContactDto.Email;
			contact.Address = updateContactDto.Address;
			contact.Phone= updateContactDto.Phone;
			contact.ContactId = updateContactDto.ContactId;
			contact.Maploctaion= updateContactDto.Maploctaion;
			contact.OpenHours= updateContactDto.OpenHours;
			_context.Contacts.Update(contact);
			_context.SaveChanges();
			return Ok("Contact updated");

		}
	}
}
