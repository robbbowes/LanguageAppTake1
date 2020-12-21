using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Language;
using API.DTOs.Sentence;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LanguageController : BaseApiController
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetLanguageDto>>>> GetLanguages()
        {
            return await _languageService.GetLanguagesAsync();
        }

        [HttpGet("{languageId}")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> GetLanguage(int languageId)
        {
            return await _languageService.GetLanguageAsync(languageId);
        }

        [HttpGet("{languageId}/sentence")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetSentenceDto>>>> GetLanguageSentences(int languageId)
        {
            return await _languageService.GetLanguageSentencesAsync(languageId);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetLanguageDto>>>> AddLanguage(AddLanguageDto newLanguage)
        {
            return await _languageService.AddLanguageAsync(newLanguage);
        }

        [HttpPut("{languageId}")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> EditLanguage(int languageId, EditLanguageDto updatedLanguage)
        {
            return await _languageService.EditLanguageAsync(languageId, updatedLanguage);
        }

        [HttpDelete("{languageId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetLanguageDto>>>> DeleteLanguage(int languageId)
        {
            return await _languageService.DeleteLanguageAsync(languageId);
        }
    }
}