using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Course;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CourseService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCourseDto>> GetCourseAsync(int id, bool includeLessons)
        {
            ServiceResponse<GetCourseDto> response = new ServiceResponse<GetCourseDto>();

            Course course;
            if (includeLessons)
            {
                course = await _context.Courses.Include(c => c.Lessons).FirstOrDefaultAsync(c => c.Id == id);
            }
            else
            {
                course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            }

            if (course == null)
            {
                response.Success = false;
                response.Message = "Course not found";
                return response;
            }

            response.Data = _mapper.Map<GetCourseDto>(course);
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetCourseDto>>> GetCoursesAsync()
        {
            ServiceResponse<IEnumerable<GetCourseDto>> response = new ServiceResponse<IEnumerable<GetCourseDto>>();
            List<Course> courses = await _context.Courses.ToListAsync();
            response.Data = courses.Select(c => _mapper.Map<GetCourseDto>(c)).ToList();
            return response;
        }
    }
}