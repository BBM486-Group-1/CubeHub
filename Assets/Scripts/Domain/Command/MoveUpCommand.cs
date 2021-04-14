using Domain.Object;

namespace Domain.Command
{
    public class MoveUpCommand : AbstractBaseMoveCommand
    {
        public MoveUpCommand(IMovable movable) : base(movable)
        {
        }

        public override void Execute()
        {
            Movable.MoveUp();
        }

        public override void Undo()
        {
            Movable.MoveDown();
        }
    }
}