using System.Collections.Generic;
using API.DTOs.Translation;

namespace API.DTOs.Sentence
{
    public class GetSentenceDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public List<GetTranslationDto> Translations { get; set; }
        public string SentenceAudio { get; set; }
        public string RecordedAudio { get; set; }
        public int LessonId { get; set; }
    }
}