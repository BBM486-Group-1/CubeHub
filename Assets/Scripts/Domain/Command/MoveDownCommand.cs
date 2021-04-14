using Domain.Object;

namespace Domain.Command
{
    public class MoveDownCommand : AbstractBaseCursorCommand
    {
        
        public MoveDownCommand(Cursor cursor) : base(cursor)
        {
        }

        public override void Execute()
        {
            Cursor.MoveDown();
        }

        public override void Undo()
        {
            Cursor.MoveUp();
        }
    }
}