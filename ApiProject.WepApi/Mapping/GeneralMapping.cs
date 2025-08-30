using ApiProject.WepApi.Dtos.FeatureDtos;
using ApiProject.WepApi.Dtos.MessageDtos;
using ApiProject.WepApi.Dtos.ProductDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;

namespace ApiProject.WepApi.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping()
		{
			CreateMap<Feature, ResultFeatureDto>().ReverseMap() ;
			CreateMap<Feature, CreatFeatureDto>().ReverseMap() ;
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap() ;
			CreateMap<Feature, GetByIdFeatureDto>().ReverseMap() ;


			CreateMap<Message, GetByIdMessageDto>().ReverseMap() ;
			CreateMap<Message, CreateMessageDto>().ReverseMap() ;
			CreateMap<Message, UpdateMessageDto>().ReverseMap() ;
			CreateMap<Message, ResultMessageDto>().ReverseMap() ;


			CreateMap<Product,CreateproductDto>().ReverseMap() ;
			CreateMap<Product,ResultProductWithCategoryDto>().ForMember(x=>x.CategoryName,y=>y.
			MapFrom(z=>z.Category.CategoryName)).ReverseMap();

		}
	}
}
