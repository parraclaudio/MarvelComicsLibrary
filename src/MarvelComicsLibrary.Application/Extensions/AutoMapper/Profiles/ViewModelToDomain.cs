using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MarvelComicsLibrary.Application.Extensions.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(x=> x.Key, opt=> opt.Ignore());

            CreateMap<ComicViewModel, Comic>()
            .ForMember(x => x.Key, opt => opt.Ignore());

            
            CreateMap<ComicQualityViewModel, ComicQuality>()
            .ForMember(x => x.Key, opt => opt.Ignore());

            CreateMap<FeedbackViewModel, Feedback>()
                .ForMember(x => x.Key, opt => opt.Ignore());

            CreateMap<CustomerViewModel, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.Valid, src.ValidationResult.Errors, src));
            CreateMap<List<CustomerViewModel>, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.FirstOrDefault().Valid, src.FirstOrDefault().ValidationResult.Errors, src));

            CreateMap<ComicViewModel, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.Valid, src.ValidationResult.Errors, src));
            CreateMap<List<ComicViewModel>, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.FirstOrDefault().Valid, src.FirstOrDefault().ValidationResult.Errors, src));

            CreateMap<ComicQualityViewModel, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.Valid, src.ValidationResult.Errors, src));
            CreateMap<List<ComicQualityViewModel>, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.FirstOrDefault().Valid, src.FirstOrDefault().ValidationResult.Errors, src));

            CreateMap<FeedbackViewModel, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.Valid, src.ValidationResult.Errors, src));
            CreateMap<List<FeedbackViewModel>, ResponseRequest>().ConstructUsing(src => new ResponseRequest(src.FirstOrDefault().Valid, src.FirstOrDefault().ValidationResult.Errors, src));
        }
    }
}
