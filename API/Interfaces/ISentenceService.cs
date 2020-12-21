using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Sentence;
using API.Entities;

namespace API.Interfaces
{
    public interface ISentenceService
    {
         public Task<ServiceResponse<GetSentenceDto>> GetSentenceAsync(int sentenceId);
    }
}