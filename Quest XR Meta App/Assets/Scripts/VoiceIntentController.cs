using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;

public class VoiceIntentController : MonoBehaviour
{
    [Header("Voice")]
    [SerializeField]
    private AppVoiceExperience appVoiceExperience;
    [SerializeField]

    public GunController gunController1;
    public GunController gunController2;
    public GunController gunController3;

    public GameObject gunOne;
    public GameObject gunTwo;
    public GameObject gunThree;

    public BulletShoot bulletShoot;
    public BulletShoot bulletShoot2;
    public BulletShoot bulletShoot3;
    public static bool appVoiceActive;
    private bool appVoiceIsActive=false;


    // Start is called before the first frame update
    void Start()
    {

        //AppVoiceExperience voiceExperience = GetComponent<AppVoiceExperience>();
        //bool isActive = voiceExperience.Active;
        //SetVoiceActive();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (SphereRay.enemyIsPointed && appVoiceActive && !appVoiceIsActive)
        {
            Debug.Log("AppVoiceIsActive: " + appVoiceActive);
            SetVoiceActive();
            appVoiceIsActive = true;
            //Debug.Log("AppVoiceIsActive: " + appVoiceActive);
        }
        
    }

    public void VoiceIsNotActive()
    {
        appVoiceActive = false;
    }

    public void StartScript(string[] info)
    {
        PrintVoice("shoot_entity",info);
    }

    public void RequestCompleted()
    {
        Debug.Log("Request has been completed");
        appVoiceIsActive = false;
        VoiceIsNotActive();
    }

    public void StartScriptOutOfScope(string info)
    {
        Debug.Log("Voice Out of Scope: " + info);
    }

    

    public void ShootVoiceCommand(string[] info)
    {
        PrintVoice("shoot_entity:", info);
        Debug.Log("ShootVoiceCommand was entered");
        appVoiceIsActive = false;

        if (info.Length > 0)
        {
            if (info[0] == "fire" && Time.time > gunController1.nextFireTime && gunOne.activeInHierarchy && appVoiceActive)
            {
                bulletShoot.ShootBullet();
                gunController1.nextFireTime = Time.time + gunController1.fireRate;
                Debug.Log("Shoot voice command was called");
            }
            if (info[0] == "fire" && Time.time > gunController2.nextFireTime && gunTwo.activeInHierarchy && appVoiceActive)
            {
                bulletShoot2.ShootBullet();
                gunController2.nextFireTime = Time.time + gunController2.fireRate;
                Debug.Log("Shoot voice command was called");
                
            }
            if (info[0] == "fire"  && Time.time > gunController3.nextFireTime && gunThree.activeInHierarchy && appVoiceActive)
            {
                bulletShoot3.ShootBullet();
                gunController3.nextFireTime = Time.time + gunController3.fireRate;
                Debug.Log("Shoot voice command was called");
            }
        }
    }

    public void SetVoiceActive()
    {
        appVoiceExperience.Activate();
        appVoiceActive = true;
        Debug.Log("Voice Experience was set to active");
    }

    public static void PrintVoice(string prefix, string[] info)
    {
        Debug.Log("Voice info full: " + info);
        foreach (var i in info)
        {
            //Logger.Instance.LogInfo($"{prefix} {i}");
            Debug.Log($"{prefix} {i}");
        }
    }


}
