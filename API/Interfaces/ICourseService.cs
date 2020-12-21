using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Course;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourseService
    {
         Task<ServiceResponse<IEnumerable<GetCourseDto>>> GetCoursesAsync();
         Task<ServiceResponse<GetCourseDto>> GetCourseAsync(int id, bool includeLessons);
        //  Task<ServiceResponse<GetCourseDto>> GetCourseLessonsAsync(int id);
    }
}