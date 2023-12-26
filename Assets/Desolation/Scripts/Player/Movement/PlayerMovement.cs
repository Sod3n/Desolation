using Zenject;

namespace Player
{ 
    public class PlayerMovement : ITickable
    {
        private Input _input;
        private Movement _movement;

        public PlayerMovement(Input input, Movement movement)
        {
            _input = input;
            _movement = movement;
        }

        public void Tick()
        {
            _movement.MovementDirection = _input.MovementDirection;

            _movement.Move();
        }
    }
}
