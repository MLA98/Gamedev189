using UnityEngine;

using Player.Command;

namespace Player.Command
{
  public class PlayerShoot : ScriptableObject, IPlayerCommand
  {

    private static Object ProjectilePrefab;
    private static float SpeedFactor = 5.0f;
    private float FireRate;
    private float LastFireTime;
    void OnEnable()
    {
      ProjectilePrefab = Resources.Load("Prefabs/Projectile");
      LastFireTime = Time.time;
    }
    public void Execute(GameObject gameObject)
    {
      FireRate = GameManager.instance.PlayerFireRate;
      var rigidBody = gameObject.GetComponent<Rigidbody>();

      if (Time.time - LastFireTime >= FireRate && GameManager.instance.Ammo >= 1)
      {
        var projectile = (GameObject)Instantiate(ProjectilePrefab,
            rigidBody.transform.localPosition + (rigidBody.transform.up * 0.2f),
            rigidBody.transform.localRotation);
        GameManager.instance.Ammo -= 1;
        if (GameManager.instance.Ammo >= 3 && GameManager.instance.spread)
        {
          var projectile2 = (GameObject)Instantiate(ProjectilePrefab, 
            rigidBody.transform.localPosition + 
                (rigidBody.transform.up * 0.2f) + 
                (rigidBody.transform.forward * 0.2f), 
            rigidBody.transform.localRotation * Quaternion.Euler(15, 0, 0));
          var projectile3 = (GameObject)Instantiate(ProjectilePrefab, 
            rigidBody.transform.localPosition + 
                (rigidBody.transform.up * 0.2f) - 
                (rigidBody.transform.forward * 0.2f), 
            rigidBody.transform.localRotation * Quaternion.Euler(-15, 0, 0));
          GameManager.instance.Ammo -= 2;
        }
        LastFireTime = Time.time;
      }
    }
  }
}
