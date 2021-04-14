namespace Domain.Command
{
    public class MoveForwardCommand : AbstractBaseMoveCommand
    {
        public MoveForwardCommand(IMovable movable) : base(movable)
        {
        }

        public override void Execute()
        {
            Movable.MoveForward();
        }

        public override void Undo()
        {
            Movable.MoveBackward();
        }
    }
}