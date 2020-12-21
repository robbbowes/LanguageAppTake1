using System.Collections.Generic;

namespace API.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string LessonAudio { get; set; }
        public List<Sentence> Sentences { get; set; }
    }
}