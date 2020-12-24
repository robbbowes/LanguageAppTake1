using System.Collections.Generic;
using API.DTOs.Lesson;
using API.Entities;

namespace API.DTOs.Course
{
    public class GetCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public List<GetLessonDto> Lessons { get; set; }
    }
}