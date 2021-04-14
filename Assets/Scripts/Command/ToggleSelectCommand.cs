namespace Command
{
    public class ToggleSelectCommand : BaseCursorCommand
    {
        public ToggleSelectCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.Toggle();
        }

        public override void Undo()
        {
            Cursor.Toggle();
        }
    }
}