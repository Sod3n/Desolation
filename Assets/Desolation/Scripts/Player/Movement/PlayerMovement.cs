using Zenject;

namespace Player
{ 
    public class PlayerMovement : IFixedTickable
    {
        private Input _input;
        private Movement _movement;
        private PlayerHealth _health;

        public PlayerMovement(Input input, Movement movement, PlayerHealth health)
        {
            _input = input;
            _movement = movement;
            _health = health;
        }

        public void FixedTick()
        {
            _movement.MovementDirection = _input.MovementDirection;

            _movement.Move();

            if (_input.TestTakeDamage) _health.TakeDamage(1);
        }
    }
}
