using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Language;
using API.DTOs.Sentence;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LanguageService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<GetLanguageDto>> AddLanguageAsync(AddLanguageDto newLanguage)
        {
            Language language = _mapper.Map<Language>(newLanguage);
            await _context.AddAsync(language);
            await _context.SaveChangesAsync();

            return await GetLanguagesAsync();
        }

        public async Task<IEnumerable<GetLanguageDto>> DeleteLanguageAsync(int languageId)
        {
            Language language = await _context.Languages.FirstOrDefaultAsync(l => l.Id == languageId);
            if (language != null)
            {
                _context.Languages.Remove(language);
                await _context.SaveChangesAsync();
            }
            return await GetLanguagesAsync();
        }

        public async Task<GetLanguageDto> EditLanguageAsync(int id, EditLanguageDto updatedLanguage)
        {
            Language language = await _context.Languages.FirstOrDefaultAsync(
                l => l.Id == updatedLanguage.Id && l.Id == id
            );
            GetLanguageDto getLanguageDto = null;
            if (language != null)
            {
                Language editedLanguage = _mapper.Map<EditLanguageDto, Language>(updatedLanguage, language);

                _context.Languages.Update(editedLanguage);
                await _context.SaveChangesAsync();

                getLanguageDto = await GetLanguageAsync(editedLanguage.Id);
            }
            return getLanguageDto;
        }

        public async Task<GetLanguageDto> GetLanguageAsync(int id)
        {
            Language language = await _context.Languages
                .Include(l => l.Courses)
                .FirstOrDefaultAsync(l => l.Id == id);
            return _mapper.Map<GetLanguageDto>(language);
        }

        public async Task<IEnumerable<GetLanguageDto>> GetLanguagesAsync()
        {
            List<Language> languages = await _context.Languages
                .Include(l => l.Courses)
                .ToListAsync();
            return languages.Select(l => _mapper.Map<GetLanguageDto>(l)).ToList();
        }

    }
}