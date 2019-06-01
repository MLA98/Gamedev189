using UnityEngine;
using Player.Command;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerCommand Clockwise;
        private IPlayerCommand CounterClockwise;
        private IPlayerCommand Shoot;
        private IPlayerCommand Jump;
        [SerializeField]
        private AudioSource ShootSound;

        void Start()
        {
            this.Clockwise = ScriptableObject.CreateInstance<MovePlayerClockwise>();
            this.CounterClockwise = ScriptableObject.CreateInstance<MovePlayerCounterClockwise>();
            this.Shoot = ScriptableObject.CreateInstance<PlayerShoot>();
            this.Jump = ScriptableObject.CreateInstance<PlayerJump>();
            Timer = 0.0f;
        }

        void FixedUpdate()
        {
            if (GameManager.instance.currState == GameManager.gameState.playing)
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
                    ShootSound.Play();
                }
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "Planet" && Input.GetButton("Fire1"))
            {
                Debug.Log("Called");
                this.Jump.Execute(this.gameObject);
            }
        }
    }
}
