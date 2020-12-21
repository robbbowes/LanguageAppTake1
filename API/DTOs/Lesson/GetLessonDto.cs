using System.Collections.Generic;
using API.DTOs.Sentence;

namespace API.DTOs.Lesson
{
    public class GetLessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string LessonAudio { get; set; }
        public List<GetSentenceDto> Sentences { get; set; }
    }
}