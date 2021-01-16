namespace API.DTOs.Translation
{
    public class PostTranslationDto
    {
        public int LanguageId { get; set; }
        public int SentenceId { get; set; }
        public string TranslatedText { get; set; }
    }
}