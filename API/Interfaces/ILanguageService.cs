using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Language;
using API.DTOs.Sentence;
using API.Entities;

namespace API.Interfaces
{
    public interface ILanguageService
    {
         Task<ServiceResponse<IEnumerable<GetLanguageDto>>> GetLanguagesAsync();
         Task<ServiceResponse<GetLanguageDto>> GetLanguageAsync(int languageId);
         Task<ServiceResponse<IEnumerable<GetLanguageDto>>> AddLanguageAsync(AddLanguageDto newLanguage);
         Task<ServiceResponse<GetLanguageDto>> EditLanguageAsync(int languageId, EditLanguageDto updatedLanguage);
         Task<ServiceResponse<IEnumerable<GetLanguageDto>>> DeleteLanguageAsync(int languageId);
    }
}