using System.Collections.Generic;
using API.DTOs.Course;
using API.DTOs.Sentence;

namespace API.DTOs.Language
{
    public class GetLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetCourseDto> Courses { get; set; }
        public List<GetSentenceDto> Translations { get; set; }
    }
}