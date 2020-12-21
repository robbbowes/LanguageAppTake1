using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Course;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourseService
    {
         Task<IEnumerable<GetCourseDto>> GetCoursesAsync();
         Task<GetCourseDto> GetCourseAsync(int id);
         Task<GetCourseDto> GetCourseLessonsAsync(int id);
    }
}