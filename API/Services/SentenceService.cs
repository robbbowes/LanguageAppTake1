using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Sentence;
using API.DTOs.Translation;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class SentenceService : ISentenceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SentenceService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetSentenceDto>> GetSentenceAsync(int sentenceId)
        {
            ServiceResponse<GetSentenceDto> response = new ServiceResponse<GetSentenceDto>();
            Sentence sentence = await _context.Sentences
                .Include(s => s.Translations).ThenInclude(t => t.Language)
                .FirstOrDefaultAsync(s => s.Id == sentenceId);
            if (sentence == null)
            {
                response.Success = false;
                response.Message = "Sentence not found";
            }
            else
            {
                response.Data = _mapper.Map<GetSentenceDto>(sentence);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetSentenceDto>>> GetSentences()
        {
            ServiceResponse<IEnumerable<GetSentenceDto>> response = new ServiceResponse<IEnumerable<GetSentenceDto>>();
            List<Sentence> sentences = await _context.Sentences.ToListAsync();
            response.Data = sentences.Select(s => _mapper.Map<GetSentenceDto>(s)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetTranslationDto>> GetTranslationAsync(int sentenceId, string languageName)
        {
            ServiceResponse<GetTranslationDto> response = new ServiceResponse<GetTranslationDto>();
            Sentence sentence = await _context.Sentences
                .Include(s => s.Translations).ThenInclude(t => t.Language)
                .FirstOrDefaultAsync(s => s.Id == sentenceId);
            if (sentence == null)
            {
                response.Success = false;
                response.Message = "Sentence not found";
                return response;
            }

            Translation translation = sentence.Translations.SingleOrDefault(t => t.Language.Name.ToLower() == languageName.ToLower());
            if (translation == null)
            {
                response.Success = false;
                response.Message = "A translation doesn't exist for " + languageName;
                return response;
            }
            response.Data = _mapper.Map<GetTranslationDto>(translation);

            return response;
        }
    }
}