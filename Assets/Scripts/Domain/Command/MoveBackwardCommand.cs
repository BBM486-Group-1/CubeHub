using Domain.Object;

namespace Domain.Command
{
    public class MoveBackwardCommand : AbstractBaseCursorCommand
    {
        public MoveBackwardCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.MoveBackward();
        }

        public override void Undo()
        {
            Cursor.MoveForward();
        }
    }
}