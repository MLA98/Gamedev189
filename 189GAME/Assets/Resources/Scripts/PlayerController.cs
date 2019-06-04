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
        private Animator Animation;
        private GameManager instance;

        void Start()
        {
            instance = GameManager.Instance;
            this.Clockwise = ScriptableObject.CreateInstance<MovePlayerClockwise>();
            this.CounterClockwise = ScriptableObject.CreateInstance<MovePlayerCounterClockwise>();
            this.Shoot = ScriptableObject.CreateInstance<PlayerShoot>();
            this.Jump = ScriptableObject.CreateInstance<PlayerJump>();
            Animation = gameObject.GetComponentInChildren<Animator>();

        }

        void FixedUpdate()
        {
            if (instance.currState == GameManager.gameState.playing)
            {
                // Movement
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    this.Clockwise.Execute(this.gameObject);
                    Animation.SetBool("Running", true);
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    this.CounterClockwise.Execute(this.gameObject);
                    Animation.SetBool("Running", true);
                }

                // Battle
                if (Input.GetButton("Jump"))
                {
                    this.Shoot.Execute(this.gameObject);
                    this.GetComponent<AudioSource>().Play();
                }
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    Animation.SetBool("Running", false);
                }
            
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "Planet" && Input.GetAxisRaw("Vertical") > 0)
            {
                this.Jump.Execute(this.gameObject);

                Animation.Play("StartJump");
            }
        }
    }
}
