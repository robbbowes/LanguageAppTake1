using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Sentence;
using API.DTOs.Translation;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SentenceController : BaseApiController
    {
        private readonly ISentenceService _sentenceService;
        public SentenceController(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<GetSentenceDto>>> GetSentences()
        {
            return await _sentenceService.GetSentences();
        }

        [HttpGet("{sentenceId}")]
        public async Task<ServiceResponse<GetSentenceDto>> GetSentence(int sentenceId)
        {
            return await _sentenceService.GetSentenceAsync(sentenceId);
        }

        [HttpGet("{sentenceId}/translation/{languageName}")]
        public async Task<ServiceResponse<GetTranslationDto>> GetTranslation(int sentenceId, string languageName)
        {
            return await _sentenceService.GetTranslationAsync(sentenceId, languageName);
        }
    }
}