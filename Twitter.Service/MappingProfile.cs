using AutoMapper;
using Twitter.Domain.Models;
using Twitter.Domain.ModelsForCreation;
using Twitter.Domain.ModelsForUpdating;

namespace Twitter.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TweetForCreationDto,Tweet>()
                .ForMember(t => t.TweetDate, opt => opt.MapFrom(tc => DateTime.UtcNow))
                .ForMember(t => t.LastUpdated, opt => opt.MapFrom(tc => DateTime.UtcNow))
                .ForMember(t => t.Medias, opt => opt.MapFrom(tc => tc.Medias!.Select(m => new Media() { MediaString = m })))
                .ForMember(t => t.PollItems, opt => opt.MapFrom(tc => tc.PollItems!.Select(pi => new PollItem { Choice = pi.Key, CountVoices = pi.Value})));
            CreateMap<TweetForUpdatingDto,Tweet>()
                .ForMember(t => t.LastUpdated, opt => opt.MapFrom(tu => DateTime.UtcNow))
                .ForMember(t => t.Medias, opt => opt.MapFrom(tu => tu.Medias!.Select(m => new Media() { MediaString = m })))
                .ForMember(t => t.PollItems, opt => opt.MapFrom(tu => tu.PollItems!.Select(pi => new PollItem { Choice = pi.Key, CountVoices = pi.Value })));
        }
    }
}
