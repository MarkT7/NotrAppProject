using NotrAppProject.Components.Data;
using NotrAppProject.Components.DbContexts;

namespace NotrAppProject.Components.Services
{
    public class NoteService : INoteService
    {
        //Dependency Injection of ApplicationDbContext to Constructor
        public readonly ApplicationDbContext _dbContext;
        public NoteService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void DeleteNote(int id)
        {
            var note = _dbContext.Notes.FirstOrDefault(y => y.Id == id);
            if (note != null)
            {
                _dbContext.Notes.Remove(note);
                _dbContext.SaveChanges();
            }
        }

        public Note GetNoteById(int id)
        {
            var note = _dbContext.Notes.FirstOrDefault(z => z.Id == id);
            return note;
        }

        public List<Note> GetNotes()
        {
            return _dbContext.Notes.ToList();
        }

        public void SaveNote(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges(true);
        }

        public void UpdateNote(Note note1)
        {

            _dbContext.Notes.Update(note1);
            _dbContext.SaveChanges(true);

        }
    }
}
