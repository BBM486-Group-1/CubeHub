namespace Command
{
    public class MoveLeftCommand : BaseCursorCommand
    {
        public MoveLeftCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.MoveLeft();
        }

        public override void Undo()
        {
            
        }
    }
}