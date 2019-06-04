using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerClockwise : ScriptableObject, IPlayerCommand
    {
        [SerializeField]
        private float moveSpeed = 3;
        private Vector3 moveDir = new Vector3(0, 0, 1);

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            var transform = gameObject.GetComponent<Transform>();
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
            var updatedPosition = rigidBody.position + rigidBody.transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime;
            rigidBody.MovePosition(updatedPosition);
        }
    }
}
