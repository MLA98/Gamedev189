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
        private float Timer;
        private enum JumpState { CD, Ready};
        private JumpState curr;
        private float JumpTime = 0.2f;
        private float JumpCD = 0.5f;

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
                if (Input.GetButton("Fire1") && curr == JumpState.Ready)
                {   
                    this.Jump.Execute(this.gameObject);
                    Timer += Time.deltaTime;
                    if(Timer >= JumpTime)
                    {
                        curr = JumpState.CD;
                        Timer = 0;
                    }
                }
                else if(curr == JumpState.CD)
                {
                    Timer += Time.deltaTime;
                    if(Timer >= JumpCD)
                    {
                        curr = JumpState.Ready;
                        Timer = 0;
                    }
                }
            }
        }
    }
}
