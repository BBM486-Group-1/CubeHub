using Domain.Object;

namespace Domain.Command
{
    public class ToggleSelectCommand : AbstractBaseCursorCommand
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