using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Lesson;
using API.DTOs.Sentence;

namespace API.Interfaces
{
    public interface ILessonService
    {
         public Task<IEnumerable<GetLessonDto>> GetLessonsAsync();
         public Task<GetLessonDto> GetLessonAsync(int lessonId);
         public Task<GetLessonDto> GetLessonSentencesAsync(int lessonId);
         public Task<GetSentenceDto> GetLessonSentenceAsync(int lessonId, int sentenceId);
    }
}