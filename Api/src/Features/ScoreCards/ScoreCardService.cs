using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data;
using RabblyApi.ScoreCards.Models;

namespace RabblyApi.ScoreCards.Services
{
    public class ScoreCardService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ScoreCardService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ScoreCard> GetScoreCard(string id)
        {
            var scoreCard = await _context.ScoreCards.FirstOrDefaultAsync(sc => sc.Id == id);
            if(scoreCard == null)
            {
                return null;
            }
            return scoreCard;
        }
    }
}