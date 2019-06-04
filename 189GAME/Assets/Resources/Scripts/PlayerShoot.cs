using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerShoot : ScriptableObject, IPlayerCommand
    {
        private GameManager instance;
        private static Object ProjectilePrefab;
        private float FireRate;
        private float LastFireTime;
        private Animator Animation;

        
        void OnEnable()
        {
            instance = GameManager.Instance;
            ProjectilePrefab = Resources.Load("Prefabs/Projectile");
            LastFireTime = Time.time;
        }
        public void Execute(GameObject gameObject)
        {
            FireRate = instance.PlayerFireRate;
            var rigidBody = gameObject.GetComponent<Rigidbody>();

            if (Time.time - LastFireTime >= FireRate && instance.Ammo >= 1)
            {
                var projectile = (GameObject)Instantiate(ProjectilePrefab,
                    rigidBody.transform.localPosition + (rigidBody.transform.up * 0.2f),
                    rigidBody.transform.localRotation);      
                instance.Ammo -= 1;

                //Handle shooting animation
                Animation = gameObject.GetComponentInChildren<Animator>();
                Animation.SetTrigger("Shoot"); 
                
                if (instance.Ammo >= 3 && instance.spread)
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
                    instance.Ammo -= 2;
                }
                LastFireTime = Time.time;
                
            }


        }
    }
}
