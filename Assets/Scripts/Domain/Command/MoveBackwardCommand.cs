namespace Domain.Command
{
    public class MoveBackwardCommand : AbstractBaseMoveCommand
    {
        public MoveBackwardCommand(IMovable movable) : base(movable)
        {
        }

        public override void Execute()
        {
            Movable.MoveBackward();
        }

        public override void Undo()
        {
            Movable.MoveForward();
        }
    }
}