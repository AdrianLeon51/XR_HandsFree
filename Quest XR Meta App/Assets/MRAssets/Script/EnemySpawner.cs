using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Meta.XR.MRUtilityKit.MRUK;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> coffinDoor = new List<GameObject>();
    [SerializeField] private List<ParticleSystem> coffinParticleSystems = new List<ParticleSystem>();
    private Transform cameraTransform;

    [SerializeField] private int spawnNumber;
    public static int spawnNumberStat;
    [SerializeField] private int spawnRate;
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private GameObject monsterPrefab2;
    [SerializeField] private GameObject monsterPrefab3;

    [SerializeField] private AudioSource audioSource;

    private List<Rigidbody> partRB = new List<Rigidbody>(); 
    
    public static int spawnCount = 0;
    private bool hasCoffinOpened = false;

    private void Awake()
    {
        //Static variable added
        spawnNumberStat = spawnNumber;
    }
    private void Start()
    {
        for (int i = 0; i < coffinDoor.Count; i++)
        {
            Rigidbody rb = coffinDoor[i].GetComponent<Rigidbody>();
            rb.isKinematic = true;
            partRB.Add(rb);
        }
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;

        Vector3 directionToPlayer = cameraTransform.position - transform.position;
        directionToPlayer.y = 0f; // Ignore the y-component

        // Create a rotation to look at the player
        Quaternion lookRotation = Quaternion.LookRotation(-directionToPlayer);

        // Apply the rotation only on the y-axis
        transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);

        
    }

    private void Update()
    {
        if (gameObject.activeSelf && gameObject.name == "Coffin(Clone)")
        {
            FacialBlendShapeController.faceIsActive = true;
            VoiceIntentController.appVoiceActive = false;
        }
        else if(gameObject.activeSelf && gameObject.name == "CoffinOppy(Clone)")
        {
            FacialBlendShapeController.faceIsActive = false;
            VoiceIntentController.appVoiceActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!hasCoffinOpened)
        {
            Debug.Log(other.name);
            audioSource.Play();
            foreach (Rigidbody rb in partRB)
            {
                rb.transform.parent = null;
                rb.isKinematic = false;
                rb.AddForce(rb.transform.up*2,ForceMode.Impulse);
            }
            foreach(ParticleSystem particleSystem in coffinParticleSystems)
            {
                particleSystem.Play();
            }
            SpawnMonsters();
            hasCoffinOpened = true;
        }
    }

    private void SpawnMonsters()
    {
        StartCoroutine(StartSpawnRoutine());
    }

    private IEnumerator StartSpawnRoutine()
    {
        Debug.Log("StartSpawnRoutine is called");
        Debug.Log("spawnCount" + spawnCount + "spawnNumber: " + spawnNumber);
        while (spawnCount < spawnNumber)
        {
            Debug.Log("Monsters are being spawned");
            yield return new WaitForSeconds(spawnRate);
            float valMonster = Random.Range(0, 3);
            GameObject monster = new GameObject();
            if (valMonster == 0)
            {
                monster = Instantiate(monsterPrefab, this.transform);
            }
            else if (valMonster == 1)
            {
                monster = Instantiate(monsterPrefab2, this.transform);
            }
            else if (valMonster == 2)
            {
                monster = Instantiate(monsterPrefab3, this.transform);
            }
            
            monster.transform.parent = null;
            monster.GetComponent<MonsterController>().ReleaseMonstor();
            spawnCount++;
        }
    }
}
