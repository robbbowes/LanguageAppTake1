using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Lesson;
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
        public async Task<ActionResult<IEnumerable<GetLessonDto>>> GetLessons()
        {
            return Ok(await _lessonService.GetLessonsAsync());
        }

        [HttpGet("{lessonId}")]
        public async Task<ActionResult<GetLessonDto>> GetLesson(int lessonId)
        {
            return Ok(await _lessonService.GetLessonAsync(lessonId));
        }

        [HttpGet("{lessonId}/sentence")]
        public async Task<ActionResult<GetLessonDto>> GetLessonSentences(int lessonId)
        {
            return Ok(await _lessonService.GetLessonSentencesAsync(lessonId));
        }

        
        [HttpGet("{lessonId}/sentence/{sentenceId}")]
        public async Task<ActionResult<GetLessonDto>> GetLessonSentence(int lessonId, int sentenceId)
        {
            return Ok(await _lessonService.GetLessonSentenceAsync(lessonId, sentenceId));
        }
    }
}