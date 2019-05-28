using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerCounterClockwise : ScriptableObject, IPlayerCommand
    {
        private float moveSpeed = 3;
        private Vector3 moveDir = new Vector3(0, 0, 1);

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.MovePosition(rigidBody.position + rigidBody.transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
