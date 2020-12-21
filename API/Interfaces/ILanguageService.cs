using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.Language;
using API.DTOs.Sentence;
using API.Entities;

namespace API.Interfaces
{
    public interface ILanguageService
    {
         Task<IEnumerable<GetLanguageDto>> GetLanguagesAsync();
         Task<GetLanguageDto> GetLanguageAsync(int languageId);
         Task<IEnumerable<GetLanguageDto>> AddLanguageAsync(AddLanguageDto newLanguage);
         Task<GetLanguageDto> EditLanguageAsync(int languageId, EditLanguageDto updatedLanguage);
         Task<IEnumerable<GetLanguageDto>> DeleteLanguageAsync(int languageId);
    }
}