using UnityEngine;

public class FacialBlendShapeController : MonoBehaviour
{

    public GameObject target;
    public float threshold = 0.6f;
    public GunController gunController1;
    public GunController gunController2;
    public GunController gunController3;

    public GameObject gunOne;
    public GameObject gunTwo;
    public GameObject gunThree;

    public BulletShoot bulletShoot;
    public BulletShoot bulletShoot2;
    public BulletShoot bulletShoot3;

    public static bool faceIsActive;

    private void Start()
    {
        faceIsActive = false;
        target.SetActive(false);
    }
    void Update()
    {
        // Get a reference to the OVRFaceExpressions component
        OVRFaceExpressions faceExpressions = GetComponent<OVRFaceExpressions>();

        // Example: Get the weight (blend shape coefficient) for a specific expression
        float tongueWeight = faceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueOut);
        Debug.Log("JawWeight: " + tongueWeight);
        if (tongueWeight >= threshold)
        {
            //Jump();
            
        }
        if (tongueWeight >= threshold && (RoomControl.generalRoom || RoomControl.room1) && Time.time > gunController1.nextFireTime && gunOne.activeInHierarchy && faceIsActive)
        {
            //gunController1.OnShoot();
            //gunController1.OnShoot();
            bulletShoot.ShootBullet();
            gunController1.nextFireTime = Time.time + gunController1.fireRate;
        }
        
        if (tongueWeight >= threshold && (RoomControl.generalRoom || RoomControl.room2) && Time.time > gunController2.nextFireTime && gunTwo.activeInHierarchy && faceIsActive)
        {
            Debug.Log("jawLeft function Shoot was in");
            //gunController2.Shoot();
            bulletShoot2.ShootBullet();
            gunController2.nextFireTime = Time.time + gunController2.fireRate;
        }
        if (tongueWeight >= threshold && (RoomControl.generalRoom || RoomControl.room2) && Time.time > gunController3.nextFireTime && gunThree.activeInHierarchy && faceIsActive)
        {
            Debug.Log("jawLeft function Shoot was in");
            //gunController2.Shoot();
            bulletShoot3.ShootBullet();
            gunController3.nextFireTime = Time.time + gunController3.fireRate;
        }


        //FaceHandleShoot(jawWeight, jawSideLeft, jawSideRight);
    }

    void FaceHandleShoot(float jawWeight,float jawSideLeft)
    {
        Debug.Log("Face Handle Shoot was called");
        Debug.Log("Face: " + threshold + " bigger " + (jawWeight >= threshold) + " " + RoomControl.generalRoom + " " + "FireTime " + gunOne.activeInHierarchy);

        if (jawWeight >= threshold && (RoomControl.generalRoom || RoomControl.room1) && Time.time > gunController1.nextFireTime && gunOne.activeInHierarchy)
        {
            Debug.Log("jawWeight function Shoot was in");
            gunController1.Shoot();
            gunController1.nextFireTime = Time.time + gunController1.fireRate;
        }
        else if (jawSideLeft >= threshold && (RoomControl.generalRoom || RoomControl.room2) && Time.time > gunController2.nextFireTime && gunTwo.activeInHierarchy)
        {
            Debug.Log("jawLeft function Shoot was in");
            gunController2.Shoot();
            gunController2.nextFireTime = Time.time + gunController2.fireRate;
        }

    }

    void Jump()
    {
        // Apply force to player character to make it jump
        //playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        target.SetActive(true);
    }
}

