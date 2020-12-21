using System.Collections.Generic;

namespace API.Entities
{
    public class Sentence
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public List<Translation> Translations { get; set; }
        public string SentenceAudio { get; set; }
        public string RecordedAudio { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
    }
}