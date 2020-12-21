using System.Collections.Generic;

namespace API.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Sentence> Sentences { get; set; }
        public List<Translation> Translations { get; set; }
    }
}