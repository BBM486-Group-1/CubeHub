namespace Command
{
    public abstract class BaseCursorCommand : ICommand
    {
        protected Cursor Cursor;

        public BaseCursorCommand(Cursor cursor)
        {
            Cursor = cursor;
        }
        
        public abstract void Execute();
        public abstract void Undo();
    }
}