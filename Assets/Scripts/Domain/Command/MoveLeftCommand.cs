namespace Domain.Command
{
    public class MoveLeftCommand : AbstractBaseMoveCommand
    {
        public MoveLeftCommand(IMovable movable) : base(movable)
        {
        }

        public override void Execute()
        {
            Movable.MoveLeft();
        }

        public override void Undo()
        {   
            Movable.MoveRight();
        }
    }
}