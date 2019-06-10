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
        private bool OnAir;
        [SerializeField] private float RunningSpeed;
        
        void Start()
        {
            instance = GameManager.Instance;
            this.Clockwise = ScriptableObject.CreateInstance<MovePlayerClockwise>();
            this.CounterClockwise = ScriptableObject.CreateInstance<MovePlayerCounterClockwise>();
            this.Shoot = ScriptableObject.CreateInstance<PlayerShoot>();
            this.Jump = ScriptableObject.CreateInstance<PlayerJump>();
            Animation = gameObject.GetComponentInChildren<Animator>();

        }

        public float GetRunningSpeed()
        {
            return RunningSpeed;
        }

        void FixedUpdate()
        {
            if (instance.currState == GameManager.gameState.playing)
            {
                // Movement
                if (SimpleInput.GetAxisRaw("Horizontal") > 0)
                {
                    this.Clockwise.Execute(this.gameObject);
                    Animation.SetBool("Running", true);
                }
                else if (SimpleInput.GetAxisRaw("Horizontal") < 0)
                {
                    this.CounterClockwise.Execute(this.gameObject);
                    Animation.SetBool("Running", true);
                }

                // Battle
                if (SimpleInput.GetButton("Jump"))
                {
                    this.Shoot.Execute(this.gameObject);
                    this.GetComponent<AudioSource>().Play();
                }
                if (SimpleInput.GetAxisRaw("Horizontal") == 0)
                {
                    Animation.SetBool("Running", false);
                }
            
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Planet" && instance.currState == GameManager.gameState.playing)
            {
                OnAir = false;
            }
            if(other.gameObject.tag == "Enemy" && OnAir == true && instance.currState == GameManager.gameState.playing)
            {
                var Enemy = other.gameObject;
                Enemy.GetComponent<EnemyController>().MeleeAttacked();
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "Planet" && SimpleInput.GetAxisRaw("Vertical") > 0 && instance.currState == GameManager.gameState.playing)
            {
                this.Jump.Execute(this.gameObject);

                Animation.Play("StartJump");
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if(other.gameObject.tag == "Planet" && instance.currState == GameManager.gameState.playing)
            {
                OnAir = true;
            }
        }
    }
}
