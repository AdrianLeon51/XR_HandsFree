using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private GameObject aimPointGaze;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet()
    {
        Debug.Log("Shoot!");
        Vector3 shotDirection = GetShotDirectionWithinSpread(bulletSpawnPoint, 1, aimPointGaze);
        GameObject newProjectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletPrefab.transform.localRotation);
        //bullet.Shoot(weaponController);
        //newProjectile.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
        newProjectile.GetComponent<Rigidbody>().AddForce(shotDirection * bulletSpeed);
        Destroy(newProjectile, 1);
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

