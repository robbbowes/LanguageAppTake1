using System.Collections.Generic;
using API.DTOs.Translation;

namespace API.DTOs.Sentence
{
    public class PostSentenceDto
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string SentenceAudio { get; set; }
        public string RecordedAudio { get; set; }
        public int LessonId { get; set; }
        public int LanguageId { get; set; }
    }
}