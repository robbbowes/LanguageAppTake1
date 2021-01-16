using System.Collections.Generic;
using API.DTOs.Sentence;

namespace API.DTOs.Lesson
{
    public class PostLessonDto
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int CourseId { get; set; }
        public string LessonAudio { get; set; }
        public List<PostSentenceDto> Sentences { get; set; }
    }
}