namespace Domain.Command
{
    public abstract  class AbstractBaseMoveCommand : ICommand
    {
        protected IMovable Movable;

        protected AbstractBaseMoveCommand(IMovable movable)
        {
            Movable = movable;
        }

        public abstract void Execute();

        public abstract void Undo();
    }
}