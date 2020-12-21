using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Lesson;
using API.DTOs.Sentence;
using API.Entities;

namespace API.Interfaces
{
    public interface ILessonService
    {
         public Task<ServiceResponse<IEnumerable<GetLessonDto>>> GetLessonsAsync();
         public Task<ServiceResponse<GetLessonDto>> GetLessonAsync(int lessonId);
         public Task<ServiceResponse<GetLessonDto>> GetLessonSentencesAsync(int lessonId);
         public Task<ServiceResponse<GetSentenceDto>> GetLessonSentenceAsync(int lessonId, int sentenceId);
    }
}