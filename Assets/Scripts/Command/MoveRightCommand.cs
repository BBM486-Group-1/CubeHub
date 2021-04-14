namespace Command
{
    public class MoveRightCommand : BaseCursorCommand
    {
        
        public MoveRightCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.MoveRight();
        }

        public override void Undo()
        { 
            
        }
    }
}