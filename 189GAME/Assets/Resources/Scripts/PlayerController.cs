using UnityEngine;
using Player.Command;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerCommand Clockwise;
        private IPlayerCommand CounterClockwise;
        private IPlayerCommand Shoot;


        void Start()
        {
            this.Clockwise = ScriptableObject.CreateInstance<MovePlayerClockwise>();
            this.CounterClockwise = ScriptableObject.CreateInstance<MovePlayerCounterClockwise>();
            this.Shoot = ScriptableObject.CreateInstance<PlayerShoot>();
        }

        void FixedUpdate()
        {
            // Movement
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                this.Clockwise.Execute(this.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                this.CounterClockwise.Execute(this.gameObject);
            }

            // Battle
            if (Input.GetButton("Jump"))
            {
                this.Shoot.Execute(this.gameObject);
            }
        }
    }
}
