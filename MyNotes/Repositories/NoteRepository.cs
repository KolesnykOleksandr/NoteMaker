using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyNotes.Components.Pages;
using MyNotes.Interfaces;
using MyNotes.Models;

namespace MyNotes.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly DBContext _context;
        public NoteRepository(DBContext context) {
            _context = context;
        }
        public async Task<IdentityResult> Add(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> Update(Note note, int id)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> Delete(int id)
        {
            Note note = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == id);

            if(note == null)
            {
                return IdentityResult.Failed();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<List<Note>> GetNotes()
        {
            var result = await _context.Notes.ToListAsync();
            return result;
        }

    }
}
