using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Sentence;
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

        public async Task<GetSentenceDto> GetSentenceAsync(int sentenceId)
        {
            return _mapper.Map<GetSentenceDto>(await _context.Sentences.FirstOrDefaultAsync(s => s.Id == sentenceId));
        }

        public async Task<IEnumerable<GetSentenceDto>> GetSentencesForLanguageAsync(int languageId)
        {
            List<Sentence> sentences = await _context.Sentences.Where(s => s.LanguageId == languageId).ToListAsync();
            return sentences.Select(s => _mapper.Map<GetSentenceDto>(s)).ToList();
        }
    }
}