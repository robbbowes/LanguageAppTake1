using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Course;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CourseController : BaseApiController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCourseDto>>>> GetCourses()
        {
            return await _courseService.GetCoursesAsync();
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<ServiceResponse<GetCourseDto>>> GetCourse(int courseId)
        {
            return await _courseService.GetCourseAsync(courseId, false);
        }

        [HttpGet("{courseId}/lesson")]
        public async Task<ActionResult<ServiceResponse<GetCourseDto>>> GetCourseLessons(int courseId)
        {
            return await _courseService.GetCourseAsync(courseId, true);
        }
    }
}