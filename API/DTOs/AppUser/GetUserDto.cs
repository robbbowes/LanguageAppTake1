using System.Collections.Generic;
using API.DTOs.Course;

namespace API.DTOs.AppUser
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<GetCourseDto> Courses { get; set; }
    }
}