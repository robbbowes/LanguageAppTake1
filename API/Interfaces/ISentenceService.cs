using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Sentence;
using API.DTOs.Translation;
using API.Entities;

namespace API.Interfaces
{
    public interface ISentenceService
    {
        public Task<ServiceResponse<IEnumerable<GetSentenceDto>>> GetSentences();
        public Task<ServiceResponse<GetSentenceDto>> GetSentenceAsync(int sentenceId);
        public Task<ServiceResponse<GetTranslationDto>> GetTranslationAsync(int sentenceId, string languageName);
    }
}