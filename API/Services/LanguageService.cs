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

        public async Task<ServiceResponse<IEnumerable<GetLanguageDto>>> AddLanguageAsync(AddLanguageDto newLanguage)
        {
            Language language = _mapper.Map<Language>(newLanguage);
            await _context.AddAsync(language);
            await _context.SaveChangesAsync();
            return await GetLanguagesAsync();
        }

        public async Task<ServiceResponse<IEnumerable<GetLanguageDto>>> DeleteLanguageAsync(int languageId)
        {
            ServiceResponse<IEnumerable<GetLanguageDto>> response = new ServiceResponse<IEnumerable<GetLanguageDto>>();
            Language language = await _context.Languages.FirstOrDefaultAsync(l => l.Id == languageId);
            if (language == null)
            {
                response.Success = false;
                response.Message = "Language not found";
            }
            else
            {
                _context.Languages.Remove(language);
                await _context.SaveChangesAsync();
                response = await GetLanguagesAsync();
            }
            return response;
        }

        public async Task<ServiceResponse<GetLanguageDto>> EditLanguageAsync(int id, EditLanguageDto updatedLanguage)
        {
            ServiceResponse<GetLanguageDto> response = new ServiceResponse<GetLanguageDto>();
            Language language = await _context.Languages.FirstOrDefaultAsync(
                l => l.Id == updatedLanguage.Id && l.Id == id
            );

            if (language != null)
            {
                response.Success = false;
                response.Message = "Language not found";
            }
            else
            {
                Language editedLanguage = _mapper.Map<EditLanguageDto, Language>(updatedLanguage, language);
                _context.Languages.Update(editedLanguage);
                await _context.SaveChangesAsync();

                response = await GetLanguageAsync(editedLanguage.Id);
            }
            return response;
        }

        public async Task<ServiceResponse<GetLanguageDto>> GetLanguageAsync(int id)
        {
            ServiceResponse<GetLanguageDto> response = new ServiceResponse<GetLanguageDto>();
            Language language = await _context.Languages
                .Include(l => l.Courses)
                .FirstOrDefaultAsync(l => l.Id == id);
            if (language == null)
            {
                response.Success = false;
                response.Message = "Language not found";
            }
            else
            {
                response.Data = _mapper.Map<GetLanguageDto>(language);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetLanguageDto>>> GetLanguagesAsync()
        {
            ServiceResponse<IEnumerable<GetLanguageDto>> response = new ServiceResponse<IEnumerable<GetLanguageDto>>();
            List<Language> languages = await _context.Languages.Include(l => l.Courses).ToListAsync();
            response.Data = languages.Select(l => _mapper.Map<GetLanguageDto>(l)).ToList();
            return response;
        }

    }
}