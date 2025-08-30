using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.ProductDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IValidator<Product> _validator;
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public ProductController(IValidator<Product> validator, ApiContext context, IMapper mapper)
		{
			_validator = validator;
			_context = context;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _context.Products.ToList();
			return Ok(values);	
		}
		[HttpPost]

		public IActionResult CreateProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));

			}
			else
			{
				_context.Products.Add(product);
				_context.SaveChanges();
				return Ok("Product created");
				//return Ok(new { message = "Product created", data = product });

			}
		}
		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var value = _context.Products.Find(id);
			_context.Products.Remove(value);
			_context.SaveChanges();
			return Ok("Product deleted");
		}
		[HttpGet("ProductGet")]
		public IActionResult GetProduct(int id)
		{
			var value = _context.Products.Find(id);
			return Ok(value);
		}


		[HttpPut]
		public IActionResult UpdateProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

			}
			else
			{
				_context.Products.Update(product);
				_context.SaveChanges();
				return Ok("Product updated");
				//return Ok(new { message = "Product created", data = product });

			}
		}
		[HttpPost("CreateProductWithCategory")]
		public IActionResult CreateProductWithCategory(CreateproductDto createproductDto)
		{
			var value = _mapper.Map<Product>(createproductDto);
			_context.Products.Add(value);
			_context.SaveChanges();
			return Ok("Created Product");
		}
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var value = _context.Products.Include(x=>x.Category).ToList();
			return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(value));
		}

	}
}
