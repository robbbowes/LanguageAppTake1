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

        public async Task<GetCourseDto> GetCourseAsync(int id)
        {
            Course course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GetCourseDto>(course);
        }

        public async Task<GetCourseDto> GetCourseLessonsAsync(int id)
        {
            Course course = await _context.Courses
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GetCourseDto>(course);
        }

        public async Task<IEnumerable<GetCourseDto>> GetCoursesAsync()
        {
            List<Course> courses = await _context.Courses
                .ToListAsync();
            return courses.Select(c => _mapper.Map<GetCourseDto>(c)).ToList();
        }
    }
}