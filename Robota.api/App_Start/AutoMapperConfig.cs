using AutoMapper;
using Robota.api.Models;
using Robota.Data.Models;

namespace Robota.api.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<CategoryViewModel, CategoryDataModel>().ReverseMap();
                config.CreateMap<PersonViewModel, PersonDataModel>().ReverseMap()
                .ForMember(dest => dest.CategoryName, opt => opt.ResolveUsing(x => x.Category.Name));
            });
        }
    }
}