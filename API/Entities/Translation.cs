namespace API.Entities
{
    public class Translation
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public Sentence Sentence { get; set; }
        public int SentenceId { get; set; }
        public string TranslatedText { get; set; }
    }
}