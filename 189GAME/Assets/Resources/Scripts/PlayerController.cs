using UnityEngine;
using Player.Command;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float PlayerSpeed;
        private IPlayerCommand Clockwise;
        private IPlayerCommand CounterClockwise;

        void Start()
        {
            this.Clockwise = ScriptableObject.CreateInstance<MovePlayerClockwise>();
            this.CounterClockwise = ScriptableObject.CreateInstance<MovePlayerCounterClockwise>();
        }

        void FixedUpdate()
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                this.Clockwise.Execute(this.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                this.CounterClockwise.Execute(this.gameObject);
            }
        }
    }
}
