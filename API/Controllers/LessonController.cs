using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Lesson;
using API.DTOs.Sentence;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LessonController : BaseApiController
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetLessonDto>>>> GetLessons()
        {
            return await _lessonService.GetLessonsAsync();
        }

        [HttpGet("{lessonId}")]
        public async Task<ActionResult<ServiceResponse<GetLessonDto>>> GetLesson(int lessonId)
        {
            return await _lessonService.GetLessonAsync(lessonId);
        }

        [HttpGet("{lessonId}/sentence")]
        public async Task<ActionResult<ServiceResponse<GetLessonDto>>> GetLessonSentences(int lessonId)
        {
            return await _lessonService.GetLessonSentencesAsync(lessonId);
        }

        
        [HttpGet("{lessonId}/sentence/{sentenceId}")]
        public async Task<ActionResult<ServiceResponse<GetSentenceDto>>> GetLessonSentence(int lessonId, int sentenceId)
        {
            return await _lessonService.GetLessonSentenceAsync(lessonId, sentenceId);
        }
    }
}