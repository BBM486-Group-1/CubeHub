using Domain.Object;

namespace Domain.Command
{
    public abstract class AbstractBaseCursorCommand : ICommand
    {
        protected Cursor Cursor;

        public AbstractBaseCursorCommand(Cursor cursor)
        {
            Cursor = cursor;
        }
        
        public abstract void Execute();
        public abstract void Undo();
    }
}