namespace Domain.Command
{
    public class MoveRightCommand : AbstractBaseMoveCommand
    {
        public MoveRightCommand(IMovable movable) : base(movable)
        {
        }

        public override void Execute()
        {
            Movable.MoveRight();
        }

        public override void Undo()
        {
            Movable.MoveLeft();
        }
    }
}