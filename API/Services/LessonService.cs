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

        public async Task<ServiceResponse<int>> AddSentenceAsync(int lessonId, PostSentenceDto postSentenceDto)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            postSentenceDto.LessonId = lessonId;
            Sentence sentence = _mapper.Map<Sentence>(postSentenceDto);
            await _context.AddAsync(sentence);
            var i = await _context.SaveChangesAsync();
            response.Data = i;
            return response;
        }

        public async Task<ServiceResponse<GetLessonDto>> GetLessonAsync(int lessonId)
        {
            ServiceResponse<GetLessonDto> response = new ServiceResponse<GetLessonDto>();
            Lesson lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson == null)
            {
                response.Success = false;
                response.Message = "Lesson not found";
            }
            else
            {
                response.Data = _mapper.Map<GetLessonDto>(lesson);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetLessonDto>>> GetLessonsAsync()
        {
            ServiceResponse<IEnumerable<GetLessonDto>> response = new ServiceResponse<IEnumerable<GetLessonDto>>();
            List<Lesson> lessons = await _context.Lessons.ToListAsync();
            response.Data = lessons.Select(l => _mapper.Map<GetLessonDto>(l)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetLessonDto>> GetLessonSentencesAsync(int lessonId)
        {
            ServiceResponse<GetLessonDto> response = new ServiceResponse<GetLessonDto>();

            Lesson lesson = await _context.Lessons
                .Include(l => l.Sentences).ThenInclude(s => s.Translations)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson == null)
            {
                response.Success = false;
                response.Message = "Lesson not found";
            }
            else
            {
                response.Data = _mapper.Map<GetLessonDto>(lesson);
            }
            return response;
        }

        public async Task<ServiceResponse<GetSentenceDto>> GetLessonSentenceAsync(int lessonId, int sentenceId)
        {
            ServiceResponse<GetSentenceDto> response = new ServiceResponse<GetSentenceDto>();
            Sentence sentence = await _context.Sentences.FirstOrDefaultAsync(s => s.LessonId == lessonId && s.Id == sentenceId);
            if (sentence == null)
            {
                response.Success = false;
                response.Message = "Sentence not found";
            }
            else
            {
                response.Data = _mapper.Map<GetSentenceDto>(sentence);
            }
            return response;
        }
    }
}