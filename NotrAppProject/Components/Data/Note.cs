using FluentValidation;

namespace NotrAppProject.Components.Data
{
    public class Note
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        //Pendiente
        //En progreso
        //Terminada
        public int State { get; set; }
    }

    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator() 
        {
            RuleFor(y => y.Title).NotEmpty().MaximumLength(80);
            RuleFor(y => y.Description).NotEmpty().MaximumLength(300);
            RuleFor(y => y.State).NotEmpty();  
        }
    }
}
