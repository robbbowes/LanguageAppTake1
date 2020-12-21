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

        public async Task<ServiceResponse<GetSentenceDto>> GetSentenceAsync(int sentenceId)
        {
            ServiceResponse<GetSentenceDto> response = new ServiceResponse<GetSentenceDto>();
            Sentence sentence = await _context.Sentences.FirstOrDefaultAsync(s => s.Id == sentenceId);
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
    }
}