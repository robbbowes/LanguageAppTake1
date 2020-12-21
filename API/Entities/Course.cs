using System.Collections.Generic;

namespace API.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public List<AppUserCourse> AppUserCourses { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}