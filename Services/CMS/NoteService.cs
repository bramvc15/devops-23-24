using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Services.CMS
{
    public class NoteService
    {
        private readonly DatabaseContext _ctx;

        public NoteService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _notes = ctx.Notes;
        }

        private readonly DbSet<Note> _notes;

        public async Task<IEnumerable<NoteDTO>> GetNotes()
        {
            List<Note> notes = await _notes.ToListAsync();
            List<NoteDTO> convertedNotes = new();

            foreach (var note in notes)
            {
                NoteDTO n = new()
                {
                    Id = note.Id,
                    Title = note.Title,
                    Content = note.Content,
                };
                convertedNotes.Add(n);
            }

            return convertedNotes;
        }

        public async Task<NoteDTO> CreateNote(NoteDTO newNote)
        {
            _notes.Add(new Note(newNote.Title, newNote.Content));
            await _ctx.SaveChangesAsync();

            return newNote;
        }

        public async Task<NoteDTO> UpdateNote(NoteDTO updatedNote)
        {
            Note note = await _notes.FindAsync(updatedNote.Id);
            note.UpdateNote(updatedNote.Title, updatedNote.Content);
            _notes.Update(note);
            await _ctx.SaveChangesAsync();

            return updatedNote;
        }

        public async Task DeleteNote(NoteDTO noteToDelete)
        {
            Note note = await _notes.FindAsync(noteToDelete.Id);
            _notes.Remove(note);
            await _ctx.SaveChangesAsync();
        }
    }
}