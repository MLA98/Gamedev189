using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerJump : ScriptableObject, IPlayerCommand
    {
        private float JumpSpeed = 50f;


        public void Execute(GameObject gameObject)
        {
            var Mars = GameObject.Find("Mars");
            var body = gameObject.transform;
            Vector3 gravityUp = (body.position - Mars.transform.position).normalized;
            Vector3 bodyUp = body.up;
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            if(rigidBody != null)
            {
                rigidBody.AddForce(rigidBody.transform.up * JumpSpeed);
                Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
                body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 100 * Time.deltaTime);
            }
        }
    }
}