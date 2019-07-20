using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Comments.Dtos;
using RabblyApi.Comments.Models;
using RabblyApi.Data;

namespace RabblyApi.Comments.Services
{
    public class CommentService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CommentService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Comment> GetComment(string id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                return null;
            }
            return comment;
        }


        /// <summary>
        /// This method will take a CommentRequestDto and attempt to add it to a debate
        /// </summary>
        public async Task<bool> CreateComment(CommentRequestDto comment)
        {
            Comment newComment = new Comment();
            newComment.Text = comment.Text;
            newComment.Debate = comment.Debate;
            newComment.CreatedBy = comment.CreatedBy;
            newComment.Parent = comment.Parent;
            try
            {
                await _context.Comments.AddAsync(newComment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
            return true;
        }

        public async Task<Comment> EditComment(string id, CommentRequestDto editComment)
        {
            // Need to figure out auth
            Comment comment = await _context.Comments
                            .Where(c => c.Id == id)
                            .Where(c => c.CreatedBy == editComment.CreatedBy)
                            .FirstAsync();
            if (comment == null)
            {
                return null;
            }
            return comment;
        }

        public async Task<bool> DeleteComment(string id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            try
            {
                _context.Remove(comment);
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