using Domain.Object;

namespace Domain.Command
{
    public class MoveForwardCommand : AbstractBaseCursorCommand
    {
        public MoveForwardCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.MoveForward();
        }

        public override void Undo()
        {
            Cursor.MoveBackward();
        }
    }
}