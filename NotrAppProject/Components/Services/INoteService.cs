using NotrAppProject.Components.Data;

namespace NotrAppProject.Components.Services
{
    public interface INoteService
    {
        List<Note> GetNotes();
        Note GetNoteById(int id);
        void SaveNote(Note note);
        void DeleteNote(int id);

        void UpdateNote(Note note);
    }
}
