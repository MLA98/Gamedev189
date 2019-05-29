using UnityEngine;

using Player.Command;

namespace Player.Command
{
  public class PlayerShoot : ScriptableObject, IPlayerCommand
  {
    private static Object ProjectilePrefab;
    private static float SpeedFactor = 5.0f;
    private float FireRate = 0.33f;
    private float LastFireTime;
    void OnEnable()
    {
      FireRate = GameManager.instance.PlayerFireRate;
      ProjectilePrefab = Resources.Load("Prefabs/Projectile");
      LastFireTime = Time.time;
    }
    public void Execute(GameObject gameObject)
    {
      var rigidBody = gameObject.GetComponent<Rigidbody>();

      if (Time.time - LastFireTime >= FireRate)
      {
        var projectile = (GameObject)Instantiate(ProjectilePrefab,
            rigidBody.transform.localPosition + (rigidBody.transform.up * 0.2f),
            rigidBody.transform.localRotation);
        LastFireTime = Time.time;
      }
    }
  }
}
