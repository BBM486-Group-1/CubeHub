namespace Domain.Command
{
    public class MoveDownCommand : AbstractBaseMoveCommand
    {
        
        public MoveDownCommand(IMovable movable) : base(movable)
        {
        }

        public override void Execute()
        {
            Movable.MoveDown();
        }

        public override void Undo()
        {
            Movable.MoveUp();
        }
    }
}