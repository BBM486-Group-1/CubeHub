using Command;
using Domain.Object;

namespace Domain.Command
{
    public class MoveRightCommand : AbstractBaseCursorCommand
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