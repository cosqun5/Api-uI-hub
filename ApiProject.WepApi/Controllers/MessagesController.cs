using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.MessageDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly ApiContext _context;
		public readonly IMapper _mapper;

		public MessagesController(IMapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var value = _context.Messages.ToList();
			return Ok(_mapper.Map<List<ResultMessageDto>>(value));
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			var value=_mapper.Map<Message>(createMessageDto);
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("created message");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return Ok("message deleted");

		}
		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)
		{
			var value = _context.Messages.Find(id);
			return Ok(_mapper.Map<GetByIdMessageDto>(value));
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var value = _mapper.Map<Message>(updateMessageDto);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Message Updated");
		}

	}
}
