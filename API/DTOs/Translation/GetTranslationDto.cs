using API.DTOs.Language;
using API.DTOs.Sentence;

namespace API.DTOs.Translation
{
    public class GetTranslationDto
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string SentenceText { get; set; }
        public string TranslatedText { get; set; }
    }
}