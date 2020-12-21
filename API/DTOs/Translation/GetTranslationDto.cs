using API.DTOs.Language;
using API.DTOs.Sentence;

namespace API.DTOs.Translation
{
    public class GetTranslationDto
    {
        public int Id { get; set; }
        public GetLanguageDto Language { get; set; }
        public GetSentenceDto Sentence { get; set; }
        public string TranslatedText { get; set; }
    }
}