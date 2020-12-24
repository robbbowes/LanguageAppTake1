using System.Linq;
using API.DTOs.AppUser;
using API.DTOs.Course;
using API.DTOs.Language;
using API.DTOs.Lesson;
using API.DTOs.Sentence;
using API.DTOs.Translation;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, GetUserDto>()
                .ForMember(
                    dest => dest.Courses,
                    opts => opts.MapFrom(
                        src => src.AppUserCourses.Select(c => c.Course)
                    )
                );

            CreateMap<Course, GetCourseDto>()
                .ForMember(
                    dest => dest.Language,
                    opts => opts.MapFrom(
                        src => src.Language.Name
                    )
                );

            CreateMap<Language, GetLanguageDto>();

            CreateMap<Lesson, GetLessonDto>();
            CreateMap<AddLanguageDto, Language>();
            CreateMap<EditLanguageDto, Language>();

            CreateMap<Sentence, GetSentenceDto>();

            CreateMap<Translation, GetTranslationDto>()
                .ForMember(
                    dest => dest.SentenceText,
                    opts => opts.MapFrom(
                        src => src.Sentence.Text
                    )
                )
                .ForMember(
                    dest => dest.Language,
                    opts => opts.MapFrom(
                        src => src.Language.Name
                    )
                );
        }
    }
}