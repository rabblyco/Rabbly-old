using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data;
using RabblyApi.Debates.Dtos;
using RabblyApi.Debates.Models;
using RabblyApi.ScoreCards.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Debates.Services
{
    public class DebateService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public DebateService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// This method will go and find the latest 12 debates created in the past 7 days
        /// </summary>
        public async Task<List<Debate>> GetDebates()
        {
            return await _context.Debates.OrderByDescending(d => d.CreatedAt).Take(12).Where(d => d.CreatedAt > DateTime.Today.AddDays(-7)).Include(d => d.ScoreCards).ToListAsync();
        }

        public async Task<List<Debate>> GetDebatesByUser(User user)
        {
            return await _context.Debates.Where(d => d.CreatedById == user.Id).Include(d => d.ScoreCards).ToListAsync();
        }

        /// <summary>
        /// This method will find a debate by Id
        /// </summary>
        public async Task<Debate> GetDebate(string id)
        {
            var debate = await _context.Debates.Include(d => d.Comments).Include(d => d.ScoreCards).FirstOrDefaultAsync(d => d.Id == id);
            if (debate == null)
            {
                return null;
            }
            return debate;
        }

        public async Task<bool> CreateDebate(DebateRequestDto debate)
        {
            Debate newDebate = new Debate();
            newDebate.Description = debate.Description;
            newDebate.Topic = debate.Topic;
            newDebate.CreatedById = debate.CreatedById;

            try
            {
                await _context.Debates.AddAsync(newDebate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public async Task<Debate> EditDebate(string id, DebateRequestDto debate)
        {
            Debate debateToEdit = await _context.Debates
                                    .Where(d => d.Id == id)
                                    .Where(d => d.CreatedById== debate.CreatedById)
                                    .FirstAsync();

            if (debate == null)
            {
                return null;
            }

            debateToEdit.Description = debate.Description;
            debate.Topic = debate.Topic;

            try
            {
                _context.Debates.Update(debateToEdit);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
            return debateToEdit;
        }

        public async Task<bool> DeleteDebate(string id)
        {
            var debate = await _context.Debates.FirstOrDefaultAsync(d => d.Id == id);
            try {
                _context.Remove(debate);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                return false;
            }
            return true;
        }
    }
}