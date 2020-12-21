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
        public async Task<ActionResult<IEnumerable<GetLanguageDto>>> GetLanguages()
        {
            return Ok(await _languageService.GetLanguagesAsync());
        }

        [HttpGet("{languageId}")]
        public async Task<ActionResult<GetLanguageDto>> GetLanguage(int languageId)
        {
            return await _languageService.GetLanguageAsync(languageId);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<GetLanguageDto>>> AddLanguage(AddLanguageDto newLanguage)
        {
            return Ok(await _languageService.AddLanguageAsync(newLanguage));
        }

        [HttpPut("{languageId}")]
        public async Task<ActionResult<GetLanguageDto>> EditLanguage(int languageId, EditLanguageDto updatedLanguage)
        {
            return Ok(await _languageService.EditLanguageAsync(languageId, updatedLanguage));
        }

        [HttpDelete("{languageId}")]
        public async Task<ActionResult<IEnumerable<GetLanguageDto>>> DeleteLanguage(int languageId)
        {
            return Ok(await _languageService.DeleteLanguageAsync(languageId));
        }
    }
}