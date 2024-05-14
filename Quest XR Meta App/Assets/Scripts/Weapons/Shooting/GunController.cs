using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public ProjectileBase bulletProjectileBase;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 600;
    public float fireRate = 0.5f;
    public float nextFireTime = 0f;

    [SerializeField] private GameObject weaponScriptRef;
    public GameObject aimPointGaze;

    public WeaponController weaponController;

    private void Start()
    {
        
    }

    private void Update()
    {        

    }



    public void OnShoot()
    {
        Debug.Log("Shoot!");
        Vector3 shotDirection = GetShotDirectionWithinSpread(bulletSpawnPoint, 1, aimPointGaze);
        ProjectileBase bullet = Instantiate(bulletProjectileBase, bulletSpawnPoint.position, Quaternion.LookRotation(shotDirection));
        bullet.Shoot(weaponController);
        Destroy(bullet, 1);
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");
        
        
        Vector3 shotDirection = GetShotDirectionWithinSpread(bulletSpawnPoint,1, aimPointGaze);
        ProjectileBase newProjectile = Instantiate(bulletProjectileBase, bulletSpawnPoint.position, Quaternion.LookRotation(shotDirection));
        Debug.Log("before newProjectile Shoot");
        newProjectile.Shoot(weaponController);
        Debug.Log("after newProjectile Shoot");

        //GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //Destroy(bullet, 1);
        // Add code for shooting effect, sound, etc.
    }

    public Vector3 GetShotDirectionWithinSpread(Transform shootTransform, float bulletSpreadAngle, GameObject aimPointGazePriv)
    {
        Vector3 spreadWorldDirection;

        if (aimPointGazePriv)
        {
            // Calculate the direction towards the target object's position
            Vector3 directionToTarget = aimPointGazePriv.transform.position - shootTransform.position;

            // Normalize the direction vector
            directionToTarget.Normalize();

            float spreadAngleRatio = bulletSpreadAngle / 180f;
            spreadWorldDirection = Vector3.Slerp(directionToTarget, aimPointGazePriv.transform.position, spreadAngleRatio);
            Debug.Log("Is using the modified SpreadWorldDirection");
        }
        else
        {
            float spreadAngleRatio = bulletSpreadAngle / 180f;
            spreadWorldDirection = Vector3.Slerp(shootTransform.forward, UnityEngine.Random.insideUnitSphere, spreadAngleRatio);
        }

        return spreadWorldDirection;
    }

}
