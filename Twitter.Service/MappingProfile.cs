using AutoMapper;
using Twitter.Domain.Models;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatedTweet, Tweet>()
                .ForMember(t => t.TweetDate, opt => opt.MapFrom(tc => DateTime.UtcNow))
                .ForMember(t => t.LastUpdated, opt => opt.MapFrom(tc => DateTime.UtcNow))
                .ForMember(t => t.Medias, opt => opt.MapFrom(tc => tc.Medias!.Select(m => new Media() { MediaString = m })))
                .ForMember(t => t.PollItems, opt => opt.MapFrom(tc => tc.PollItems!.Select(pi => new PollItem { Choice = pi, CountVoices = 0 })));
            CreateMap<UpdatedTweet,Tweet>()
                .ForMember(t => t.LastUpdated, opt => opt.MapFrom(tu => DateTime.UtcNow))
                .ForMember(t => t.Medias, opt => opt.MapFrom(tu => tu.Medias!.Select(m => new Media() { MediaString = m })))
                .ForMember(t => t.PollItems, opt => opt.MapFrom(tu => tu.PollItems!.Select(pi => new PollItem { Choice = pi, CountVoices = 0 })));

            CreateMap<CreatedAuthor, Author>()
                .ForMember(a => a.Handle, opt => opt.MapFrom(ac => $"@{ac.Handle}"))
                .ForMember(a => a.JoinDate, opt => opt.MapFrom(ac => DateTime.UtcNow));
            CreateMap<UpdatedAuthor, Author>()
                .ForMember(a => a.Handle, opt => opt.MapFrom(ac => $"@{ac.Handle}"));
        }
    }
}
