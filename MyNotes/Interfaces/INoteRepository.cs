using Microsoft.AspNetCore.Identity;
using MyNotes.Models;

namespace MyNotes.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotes();
        Task<IdentityResult> Add(Note note);
        Task<IdentityResult> Update(Note note, int id);
        Task<IdentityResult> Delete(int id);
        
    }
}
