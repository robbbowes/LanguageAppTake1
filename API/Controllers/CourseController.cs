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
        public async Task<ActionResult<IEnumerable<GetCourseDto>>> GetCourses()
        {
            return Ok(await _courseService.GetCoursesAsync());
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<GetCourseDto>> GetCourse(int courseId)
        {
            return await _courseService.GetCourseAsync(courseId);
        }

        [HttpGet("{courseId}/lesson")]
        public async Task<ActionResult<GetCourseDto>> GetCourseLessons(int courseId)
        {
            return await _courseService.GetCourseLessonsAsync(courseId);
        }
    }
}