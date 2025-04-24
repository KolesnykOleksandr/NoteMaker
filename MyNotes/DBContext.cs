using Microsoft.EntityFrameworkCore;
using MyNotes.Models;

namespace MyNotes
{
    public class DBContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.NoteId);
            });

        }
    }
}
