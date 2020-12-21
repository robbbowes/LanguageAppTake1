using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Lesson;
using API.DTOs.Sentence;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class LessonService : ILessonService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LessonService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetLessonDto> GetLessonAsync(int lessonId)
        {
            return _mapper.Map<GetLessonDto>(
                await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId)
            );
        }

        public async Task<IEnumerable<GetLessonDto>> GetLessonsAsync()
        {
            List<Lesson> lessons = await _context.Lessons.ToListAsync();
            return lessons.Select(l => _mapper.Map<GetLessonDto>(l)).ToList();
        }

        public async Task<GetLessonDto> GetLessonSentencesAsync(int lessonId)
        {
            return _mapper.Map<GetLessonDto>(
                await _context.Lessons
                    .Include(l => l.Sentences)
                    .FirstOrDefaultAsync(l => l.Id == lessonId)                
            );
        }

        public async Task<GetSentenceDto> GetLessonSentenceAsync(int lessonId, int sentenceId)
        {
            Sentence sentence = await _context.Sentences.FirstOrDefaultAsync(s => s.LessonId == lessonId && s.Id == sentenceId);
            return _mapper.Map<GetSentenceDto>(sentence);
        }
    }
}