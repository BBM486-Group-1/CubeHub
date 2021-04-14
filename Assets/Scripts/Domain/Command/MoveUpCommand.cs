using Domain.Object;

namespace Domain.Command
{
    public class MoveUpCommand : AbstractBaseCursorCommand
    {
        public MoveUpCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.MoveUp();
        }

        public override void Undo()
        {
            Cursor.MoveDown();
        }
    }
}