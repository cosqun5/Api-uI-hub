using ApiProject.WepApi.Entities;
using FluentValidation;

namespace ApiProject.WepApi.ValidationRules
{
	public class ProductValidator:AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.ProductName).NotEmpty().WithMessage("Məhsul adını qeyd edin.");
			RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ən az 2 simvol yazın.");
			RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ən fazla 50 simvol yazın");

			RuleFor(x => x.Price).NotEmpty().WithMessage("Məhsulun qiymətini yazın.").GreaterThan(0).WithMessage("Məhsulun dəyəri negatif ola bilməz")
				.LessThan(1000).WithMessage("Məhsulun qiyməti bu qədər yüksək ola bilməz");

			RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Məhsulun məlumatı yazılmalıdır.");
		}
	}
}
