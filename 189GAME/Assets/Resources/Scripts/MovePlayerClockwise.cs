using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerClockwise : ScriptableObject, IPlayerCommand
    {
        private Vector3 moveDir = new Vector3(0, 0, 1f);

        public void Execute(GameObject gameObject)
        {
            var player = gameObject.GetComponent<PlayerController>();
            float moveSpeed = player.GetRunningSpeed();
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            var transform = gameObject.GetComponent<Transform>();
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
            var updatedPosition = rigidBody.position + rigidBody.transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime;
            rigidBody.MovePosition(updatedPosition);
        }
    }
}
