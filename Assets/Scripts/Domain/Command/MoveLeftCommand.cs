using Command;
using Domain.Object;

namespace Domain.Command
{
    public class MoveLeftCommand : AbstractBaseCursorCommand
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