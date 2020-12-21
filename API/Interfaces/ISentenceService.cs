using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Sentence;

namespace API.Interfaces
{
    public interface ISentenceService
    {
         public Task<IEnumerable<GetSentenceDto>> GetSentencesForLanguageAsync(int languageId);
         public Task<GetSentenceDto> GetSentenceAsync(int sentenceId);

    }
}